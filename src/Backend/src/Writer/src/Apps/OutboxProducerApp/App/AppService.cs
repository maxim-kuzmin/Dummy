using System.Text;
using RabbitMQ.Client;

namespace Makc.Dummy.Writer.Apps.OutboxProducerApp.App;

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

      const int timeoutToRepeat = 1000;

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

        while (true)
        {
          await Publish(channel, stoppingToken);

          var task = await Task.WhenAny(Task.Delay(timeoutToRepeat, stoppingToken), tcs.Task);

          if (task == tcs.Task)
          {
            break;
          }
        }        
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

  private async Task Publish(IChannel channel, CancellationToken cancellationToken)
  {
    const string exchange = "DummyItemChanged";

    await channel.ExchangeDeclareAsync(
      exchange: exchange,
      type: ExchangeType.Fanout,
      cancellationToken: cancellationToken);

    string message = DateTimeOffset.Now.ToString();

    var body = Encoding.UTF8.GetBytes(message);

    await channel.BasicPublishAsync(
      exchange: exchange,
      routingKey: string.Empty,
      body: body,
      cancellationToken: cancellationToken);

    _logger.LogInformation("MAKC:Published: {message}", message);
  }
}
