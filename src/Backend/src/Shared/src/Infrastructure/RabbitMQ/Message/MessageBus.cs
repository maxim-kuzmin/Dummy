namespace Makc.Dummy.Shared.Infrastructure.RabbitMQ.Message;

/// <summary>
/// Шина сообщений.
/// </summary>
public abstract class MessageBus : MessageBusBase
{
  private readonly ConnectionFactory _connectionFactory;

  private readonly ILogger _logger;

  private readonly int _timeoutToRetry;

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="options">Параметры.</param>
  /// <param name="logger">Логгер.</param>
  public MessageBus(AppConfigOptionsRabbitMQSection? options, ILogger logger)
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

    _timeoutToRetry = options.TimeoutInMillisecondsToRetry;
  }

  /// <inheritdoc/>
  public sealed override Task Connect(CancellationToken cancellationToken)
  {
    TaskCompletionSource connectionCompletion = new();

    Task FuncToExecute(
      IChannel channel,
      TaskCompletionSource shutdownCompletion,
      CancellationToken cancellationToken)
    {
      TaskCompletionSource consumingCompletion = new();

      Task.Run(() => Consume(channel, consumingCompletion, cancellationToken), cancellationToken);

      TaskCompletionSource producingCompletion = new();

      Task.Run(() => Produce(channel, producingCompletion, shutdownCompletion, cancellationToken), cancellationToken);

      return Task.WhenAll(consumingCompletion.Task, producingCompletion.Task);
    }

    Task.Run(() => Connect(connectionCompletion, FuncToExecute, cancellationToken), cancellationToken);

    return connectionCompletion.Task;
  }

  /// <summary>
  /// Опубликовать.
  /// </summary>
  /// <param name="channel">Канал.</param>
  /// <param name="receiver">Получатель.</param>
  /// <param name="message">Сообщение.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  protected abstract Task Publish(
    IChannel channel,
    string receiver,
    string message,
    CancellationToken cancellationToken);

  /// <summary>
  /// Подписаться.
  /// </summary>
  /// <param name="channel">Канал.</param>
  /// <param name="sender">Отправитель.</param>
  /// <param name="funcToHandleMessage">Функция для обработки сообщения.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  protected abstract Task Subscribe(
    IChannel channel,
    string sender,
    MessageFuncToHandle funcToHandleMessage,
    CancellationToken cancellationToken);

  private async Task Connect(
    TaskCompletionSource connectionCompletion,
    Func<IChannel, TaskCompletionSource, CancellationToken, Task> funcToExecute,
    CancellationToken cancellationToken)
  {
    while (!cancellationToken.IsCancellationRequested)
    {
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

        using var channel = await connection.CreateChannelAsync(null, cancellationToken).ConfigureAwait(false);

        await funcToExecute.Invoke(channel, shutdownCompletion, cancellationToken).ConfigureAwait(false);

        connectionCompletion.SetResult();

        await shutdownCompletion.Task.ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "MAKC:Unknown");
      }

      await Task.Delay(_timeoutToRetry, cancellationToken).ConfigureAwait(false);
    }
  }

  private async Task Consume(
    IChannel channel,
    TaskCompletionSource consumingCompletion,
    CancellationToken cancellationToken)
  {
    if (!consumingCompletion.Task.IsCompleted)
    {
      consumingCompletion.SetResult();
    }

    await foreach (var receiving in Receivings.Reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
    {
      var task = Subscribe(channel, receiving.Sender, receiving.FuncToHandleMessage, cancellationToken);

      await task.ConfigureAwait(false);
    }
  }

  private async Task Produce(
    IChannel channel,
    TaskCompletionSource producingCompletion,
    TaskCompletionSource shutdownCompletion,
    CancellationToken cancellationToken)
  {
    if (!producingCompletion.Task.IsCompleted)
    {
      producingCompletion.SetResult();
    }

    await foreach (var sending in Sendings.Reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
    {
      var publishingTask = Publish(channel, sending.Receiver, sending.Message, cancellationToken);

      var completionTask = await Task.WhenAny(publishingTask, shutdownCompletion.Task).ConfigureAwait(false);

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
}
