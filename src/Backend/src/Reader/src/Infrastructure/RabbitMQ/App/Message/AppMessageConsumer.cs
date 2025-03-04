﻿namespace Makc.Dummy.Reader.Infrastructure.RabbitMQ.App.Message;

/// <summary>
/// Потребитель сообщений приложения.
/// </summary>
public class AppMessageConsumer : IAppMessageConsumer
{
  private readonly ConnectionFactory _connectionFactory;

  private readonly ILogger<AppMessageConsumer> _logger;

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="options">Параметры.</param>
  /// <param name="_logger">Логгер.</param>
  public AppMessageConsumer(
    AppConfigOptionsRabbitMQSection? options,
    ILogger<AppMessageConsumer> logger)
  {
    _logger = logger;

    Guard.Against.Null(options);

    _connectionFactory = new()
    {
      HostName = options.HostName,
      Password = options.Password,
      Port = options.Port,
      UserName = options.UserName
    };
  }

  /// <inheritdoc/>
  public Task Start(IEnumerable<MessageReceiving> receivings, CancellationToken cancellationToken)
  {
    Task.Run(() => Consume(receivings, cancellationToken), cancellationToken);

    return Task.CompletedTask;
  }

  /// <inheritdoc/>
  public async Task Consume(IEnumerable<MessageReceiving> receivings, CancellationToken cancellationToken)
  {
    while (!cancellationToken.IsCancellationRequested)
    {
      const int timeoutToRetry = 3000;

      try
      {
        using var connection = await _connectionFactory.CreateConnectionAsync(cancellationToken);

        _logger.LogInformation("MAKC:Connected");

        TaskCompletionSource shutdownCompletion = new();

        connection.ConnectionShutdownAsync += (e, a) =>
        {
          _logger.LogInformation("MAKC:Shutdown");

          if (!shutdownCompletion.Task.IsCompleted)
          {
            shutdownCompletion.SetResult();
          }

          return Task.CompletedTask;
        };

        using var channel = await connection.CreateChannelAsync(null, cancellationToken);

        foreach (var receiving in receivings)
        {
          await Subscribe(channel, receiving.Sender, receiving.FuncToHandleMessage, cancellationToken);
        }

        await shutdownCompletion.Task;
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "MAKC:Unknown");
      }

      await Task.Delay(timeoutToRetry, cancellationToken);
    }
  }

  private static async Task Subscribe(
    IChannel channel,
    string sender,
    MessageFuncToHandle funcToHandleMessage,
    CancellationToken cancellationToken)
  {    
    const string queue = "Makc.Dummy.Reader";

    string exchange = $"Makc.Dummy.{sender}";

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

      await funcToHandleMessage.Invoke(sender, message, cancellationToken);      

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
