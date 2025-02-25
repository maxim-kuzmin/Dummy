namespace Makc.Dummy.Writer.Infrastructure.RabbitMQ.App.Message;

/// <summary>
/// Поставщик сообщений приложения.
/// </summary>
/// <param name="options">Параметры.</param>
/// <param name="_logger">Логгер.</param>
public class AppMessageProducer(
  AppConfigOptionsRabbitMQSection options,
  ILogger<AppMessageProducer> _logger) : IAppMessageProducer
{
  private readonly ConnectionFactory _connectionFactory = new()
  {
    HostName = options.HostName,
    Password = options.Password,
    Port = options.Port,
    UserName = options.UserName
  };

  private readonly Channel<MessageSending> _sendings = Channel.CreateUnbounded<MessageSending>(new()
  {
    SingleWriter = false,
    SingleReader = false,
    AllowSynchronousContinuations = true
  });

  /// <inheritdoc/>
  public ValueTask Publish(MessageSending sending, CancellationToken cancellationToken)
  {
    return _sendings.Writer.WriteAsync(sending, cancellationToken);
  }

  /// <inheritdoc/>
  public Task Start(CancellationToken cancellationToken)
  {
    TaskCompletionSource completion = new();

    Task.Run(() => Produce(completion, cancellationToken), cancellationToken);

    return completion.Task;
  }

  private async Task Produce(TaskCompletionSource completion, CancellationToken cancellationToken)
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

        if (!completion.Task.IsCompleted)
        {
          completion.SetResult();
        }

        await foreach (var sending in _sendings.Reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
        {
          var publishingTask = Publish(channel, sending.Receiver, sending.Message, cancellationToken);

          var completionTask = await Task.WhenAny(publishingTask, shutdownCompletion.Task);

          if (completionTask == shutdownCompletion.Task)
          {
            sending.Cancel(cancellationToken);

            break;
          }
          else
          {
            sending.Complete();
          }
        }
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "MAKC:Unknown");
      }

      await Task.Delay(timeoutToRetry, cancellationToken);
    }
  }

  private async Task Publish(IChannel channel, string receiver, string message, CancellationToken cancellationToken)
  {
    string exchange = $"Makc.Dummy.{receiver}";

    await channel.ExchangeDeclareAsync(
      exchange: exchange,
      type: ExchangeType.Fanout,
      cancellationToken: cancellationToken);

    var body = Encoding.UTF8.GetBytes(message);

    var properties = new BasicProperties
    {
      Persistent = true
    };

    await channel.BasicPublishAsync(
      exchange: exchange,
      routingKey: string.Empty,
      mandatory: true,      
      basicProperties: properties,
      body: body,
      cancellationToken: cancellationToken);

    _logger.LogInformation("MAKC:Published: {message}", message);
  }
}
