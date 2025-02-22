using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Makc.Dummy.Reader.Apps.InboxConsumerApp.App;

/// <summary>
/// Сервис приложения.
/// </summary>
/// <param name="_logger">Логгер.</param>
/// <param name="_serviceScopeFactory">Фабрика области видимости сервисов.</param>
public class AppService(ILogger<AppService> _logger, IServiceScopeFactory _serviceScopeFactory) : BackgroundService
{
  /// <inheritdoc/>
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (!stoppingToken.IsCancellationRequested)
    {
      using IServiceScope scope = _serviceScopeFactory.CreateScope();

      var appConfigOptionsSnapshot = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<AppConfigOptions>>();

      var appConfigOptionsRabbitMQSection = Guard.Against.Null(appConfigOptionsSnapshot.Value.RabbitMQ);

      const int timeoutToRetry = 3000;

      var connectionFactory = CreateConnectionFactory(appConfigOptionsRabbitMQSection);

      try
      {
        using var connection = await connectionFactory.CreateConnectionAsync(stoppingToken);

        _logger.LogInformation("MAKC:Connected");

        var tcs = new TaskCompletionSource();

        connection.ConnectionShutdownAsync += (e, a) =>
        {
          _logger.LogInformation("MAKC:Shutdown");

          tcs.SetResult();

          return Task.CompletedTask;
        };

        using var channel = await connection.CreateChannelAsync(null, stoppingToken);        

        await Subscribe(channel, stoppingToken);

        await tcs.Task;
      }
      catch (TaskCanceledException ex)
      {
        _logger.LogError(ex, "MAKC: Canceled");

        break;
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "MAKC: Unknown");
      }

      await Task.Delay(timeoutToRetry, stoppingToken);
    }
  }

  private static ConnectionFactory CreateConnectionFactory(AppConfigOptionsRabbitMQSection options)
  {
    return new()
    {
      HostName = options.HostName,
      Password = options.Password,
      Port = options.Port,
      UserName = options.UserName,
    };
  }

  private async Task Subscribe(IChannel channel, CancellationToken cancellationToken)
  {
    const string exchange = "DummyItemChanged";
    const string queue = "Makc.Dummy.Reader";

    await channel.ExchangeDeclareAsync(
      exchange: exchange,
      type: ExchangeType.Fanout,
      cancellationToken: cancellationToken);

    await channel.QueueDeclareAsync(
      queue: queue,
      durable: true,
      exclusive: false,
      autoDelete: false,
      arguments: null,
      cancellationToken: cancellationToken);

    await channel.QueueBindAsync(
      queue: queue,
      exchange: exchange,
      routingKey: string.Empty,
      cancellationToken: cancellationToken);

    await channel.BasicQosAsync(
      prefetchSize: 0,
      prefetchCount: 1,
      global: false,
      cancellationToken: cancellationToken);

    var consumer = new AsyncEventingBasicConsumer(channel);

    consumer.ReceivedAsync += async (model, ea) =>
    {
      byte[] body = ea.Body.ToArray();

      var message = Encoding.UTF8.GetString(body);

      _logger.LogInformation("MAKC:Received: {message}", message);

      // here channel could also be accessed as ((AsyncEventingBasicConsumer)sender).Channel
      await channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
    };

    await channel.BasicConsumeAsync(
      queue: queue,
      autoAck: false,
      consumer: consumer,
      cancellationToken: cancellationToken);
  }
}
