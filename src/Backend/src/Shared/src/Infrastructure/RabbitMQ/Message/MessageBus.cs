namespace Makc.Dummy.Shared.Infrastructure.RabbitMQ.Message;

/// <summary>
/// Шина сообщений.
/// </summary>
public abstract class MessageBus : MessageBusBase
{
  private readonly ConnectionFactory _connectionFactory;

  private readonly AppConfigOptionsMessageDirectionEnum _direction;

  private readonly ILogger _logger;

  private readonly int _timeoutToRetry;

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="options">Параметры.</param>
  /// <param name="logger">Логгер.</param>
  public MessageBus(AppConfigOptionsRabbitMQSection? options, ILogger logger) : base(logger)
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

    _direction = options.Direction;

    _timeoutToRetry = options.TimeoutInMillisecondsToRetry;
  }

  /// <inheritdoc/>
  public sealed override Task Connect(CancellationToken cancellationToken)
  {
    if (cancellationToken.IsCancellationRequested)
    {
      return Task.FromCanceled(cancellationToken);
    }

    if (!Init(_direction))
    {
      return Task.CompletedTask;
    }

    TaskCompletionSource connectionCompletion = new();

    Task FuncToExecute(IChannel channel, TaskCompletionSource shutdownCompletion, CancellationToken cancellationToken)
    {
      TaskCompletionSource consumingCompletion = new();

      if (ReceivingChannel != null)
      {
        var consumingTask = Task.Run(
          () => Consume(ReceivingChannel, channel, consumingCompletion, shutdownCompletion, cancellationToken),
          cancellationToken);

        if (consumingTask.IsCanceled)
        {
          return consumingTask;
        }
      }
      else
      {
        consumingCompletion.SetResult();
      }

      TaskCompletionSource producingCompletion = new();

      if (SendingChannel != null)
      {
        var producingTask = Task.Run(
          () => Produce(SendingChannel, channel, producingCompletion, shutdownCompletion, cancellationToken),
          cancellationToken);

        if (producingTask.IsCanceled)
        {
          return producingTask;
        }
      }
      else
      {
        producingCompletion.SetResult();
      }

      return Task.WhenAll(consumingCompletion.Task, producingCompletion.Task);
    }

    var connectionTask = Task.Run(
      () => Connect(connectionCompletion, FuncToExecute, cancellationToken),
      cancellationToken);

    if (connectionTask.IsCanceled)
    {
      return connectionTask;
    }

    return connectionCompletion.Task;
  }

  /// <summary>
  /// Получить.
  /// </summary>  
  /// <param name="receiving">Получение.</param>
  /// <param name="receivingCompletion">Завершение получения.</param>
  /// <param name="channel">Канал.</param>
  /// <param name="shutdownCompletion">Завершение отключения.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  protected abstract Task Receive(
    MessageReceiving receiving,
    TaskCompletionSource receivingCompletion,
    IChannel channel,
    TaskCompletionSource shutdownCompletion,
    CancellationToken cancellationToken);

  /// <summary>
  /// Отправить.
  /// </summary>  
  /// <param name="sending">Отправка.</param>
  /// <param name="channel">Канал.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  protected abstract Task Send(MessageSending sending, IChannel channel, CancellationToken cancellationToken);

  private async Task Connect(
    TaskCompletionSource connectionCompletion,
    Func<IChannel, TaskCompletionSource, CancellationToken, Task> funcToExecute,
    CancellationToken cancellationToken)
  {
    while (!cancellationToken.IsCancellationRequested)
    {
      try
      {
        using var connection = await _connectionFactory.CreateConnectionAsync(cancellationToken).ConfigureAwait(false);

        _logger.LogDebug("MAKC:Connecting:Connection created");

        TaskCompletionSource shutdownCompletion = new();

        connection.ConnectionShutdownAsync += (e, a) =>
        {
          _logger.LogDebug("MAKC:Connecting:ConnectionShutdown");

          Shutdown(shutdownCompletion);

          return Task.CompletedTask;
        };

        using var channel = await connection.CreateChannelAsync(null, cancellationToken).ConfigureAwait(false);

        _logger.LogDebug("MAKC:Connecting:Channel created");

        await funcToExecute.Invoke(channel, shutdownCompletion, cancellationToken).ConfigureAwait(false);

        if (!connectionCompletion.Task.IsCompleted)
        {
          connectionCompletion.SetResult();
        }
        else
        {
          ResetShutdown();
        }

        _logger.LogDebug("MAKC:Connecting:Connected");

        await shutdownCompletion.Task.ConfigureAwait(false);

        _logger.LogDebug("MAKC:Connecting:Shutdown");
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "MAKC:Connecting:Unknown");
      }

      await Task.Delay(_timeoutToRetry, cancellationToken).ConfigureAwait(false);
    }
  }

  private async Task Consume(
    Channel<MessageReceiving> receivingChannel,
    IChannel channel,
    TaskCompletionSource consumingCompletion,
    TaskCompletionSource shutdownCompletion,
    CancellationToken cancellationToken)
  {
    if (!consumingCompletion.Task.IsCompleted)
    {
      consumingCompletion.SetResult();
    }

    _logger.LogDebug("MAKC:Consuming:Start");

    await foreach (var receiving in receivingChannel.Reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
    {
      if (CheckShutdown(shutdownCompletion, cancellationToken))
      {
        break;
      }

      try
      {
        await Receive(receiving, channel, shutdownCompletion, cancellationToken).ConfigureAwait(false);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "MAKC:Consuming:Receive:Unknown");

        Shutdown(shutdownCompletion);

        break;
      }
    }

    _logger.LogDebug("MAKC:Consuming:End");
  }

  private async Task Produce(
    Channel<MessageSending> sendingChannel,
    IChannel channel,
    TaskCompletionSource producingCompletion,
    TaskCompletionSource shutdownCompletion,
    CancellationToken cancellationToken)
  {
    if (!producingCompletion.Task.IsCompleted)
    {
      producingCompletion.SetResult();
    }

    _logger.LogDebug("MAKC:Producing:Start");

    await foreach (var sending in sendingChannel.Reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
    {
      if (CheckShutdown(shutdownCompletion, cancellationToken))
      {
        sending.Cancel(cancellationToken);

        break;
      }

      try
      {
        await Send(sending, channel, cancellationToken).ConfigureAwait(false);

        sending.Complete();
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "MAKC:Producing:Send:Unknown");

        Shutdown(shutdownCompletion);

        break;
      }
    }

    _logger.LogDebug("MAKC:Producing:End");
  }

  private Task Receive(
    MessageReceiving receiving,
    IChannel channel,
    TaskCompletionSource shutdownCompletion,
    CancellationToken cancellationToken)
  {
    TaskCompletionSource receivingCompletion = new();

    var receivingTask = Task.Run(
      () => Receive(receiving, receivingCompletion, channel, shutdownCompletion, cancellationToken),
      cancellationToken);

    if (receivingTask.IsCanceled)
    {
      return receivingTask;
    }

    return receivingCompletion.Task;
  }
}
