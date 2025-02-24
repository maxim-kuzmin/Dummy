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

  private readonly Channel<AppMessageSending> _sendings = Channel.CreateUnbounded<AppMessageSending>(new()
  {
    SingleWriter = false,
    SingleReader = false,
    AllowSynchronousContinuations = true
  });

  /// <inheritdoc/>
  public ValueTask Publish(AppMessageSending sending, CancellationToken cancellationToken)
  {
    return _sendings.Writer.WriteAsync(sending, cancellationToken);
  }

  /// <inheritdoc/>
  public Task Start(CancellationToken cancellationToken)
  {
    TaskCompletionSource tcs = new();

    Task.Run(() => Produce(tcs, cancellationToken), cancellationToken);

    return tcs.Task;
  }

  private async Task Produce(TaskCompletionSource tcs, CancellationToken cancellationToken)
  {
    while (!cancellationToken.IsCancellationRequested)
    {
      const int timeoutToRetry = 3000;

      try
      {
        using var connection = await _connectionFactory.CreateConnectionAsync(cancellationToken);

        _logger.LogInformation("MAKC:Connected");

        var onShutdown = new TaskCompletionSource();

        connection.ConnectionShutdownAsync += (e, a) =>
        {
          _logger.LogInformation("MAKC:Shutdown");

          if (!onShutdown.Task.IsCompleted)
          {
            _logger.LogInformation("MAKC:Shutdown:SetResult");

            onShutdown.SetResult();
          }

          return Task.CompletedTask;
        };

        using var channel = await connection.CreateChannelAsync(null, cancellationToken);

        tcs.SetResult();

        await foreach (var sending in _sendings.Reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
        {
          var taskToPublish = Publish(channel, sending.Receiver, sending.Message, cancellationToken);

          var taskToComplete = await Task.WhenAny(taskToPublish, onShutdown.Task);

          if (taskToComplete == onShutdown.Task)
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

  private async Task Publish(IChannel channel, string exchange, string message, CancellationToken cancellationToken)
  {
    await channel.ExchangeDeclareAsync(
      exchange: exchange,
      type: ExchangeType.Fanout,
      cancellationToken: cancellationToken);

    var body = Encoding.UTF8.GetBytes(message);

    await channel.BasicPublishAsync(
      exchange: exchange,
      routingKey: string.Empty,
      body: body,
      cancellationToken: cancellationToken);

    _logger.LogInformation("MAKC:Published: {message}", message);
  }
}
