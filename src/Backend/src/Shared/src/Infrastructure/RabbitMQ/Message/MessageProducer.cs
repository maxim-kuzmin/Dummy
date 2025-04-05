namespace Makc.Dummy.Shared.Infrastructure.RabbitMQ.Message;

/// <summary>
/// Поставщик сообщений.
/// </summary>
public abstract class MessageProducer : IMessageProducer
{
  private readonly ConnectionFactory _connectionFactory;

  private readonly ILogger _logger;

  private readonly Channel<MessageSending> _sendings = Channel.CreateUnbounded<MessageSending>(new()
  {
    SingleWriter = false,
    SingleReader = false,
    AllowSynchronousContinuations = true
  });

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="options">Параметры.</param>
  /// <param name="logger">Логгер.</param>
  public MessageProducer(AppConfigOptionsRabbitMQSection? options, ILogger logger)
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

  /// <summary>
  /// Опубликовать.
  /// </summary>
  /// <param name="channel">Канал.</param>
  /// <param name="receiver">Получатель.</param>
  /// <param name="message">Сообщение.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns></returns>
  protected abstract Task Publish(
    IChannel channel,
    string receiver,
    string message,
    CancellationToken cancellationToken);
}
