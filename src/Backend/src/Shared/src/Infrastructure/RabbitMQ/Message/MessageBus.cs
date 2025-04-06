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

    _direction = options.Direction;

    _timeoutToRetry = options.TimeoutInMillisecondsToRetry;
  }

  /// <inheritdoc/>
  public sealed override Task Connect(CancellationToken cancellationToken)
  {
    if (!Init(_direction))
    {
      return Task.CompletedTask;
    }

    TaskCompletionSource connectionCompletion = new();

    Task FuncToExecute(
      IChannel channel,
      TaskCompletionSource shutdownCompletion,
      CancellationToken cancellationToken)
    {
      TaskCompletionSource consumingCompletion = new();

      if (Receivings != null)
      {
        Task.Run(
          () => Consume(Receivings, channel, consumingCompletion, cancellationToken),
          cancellationToken);
      }
      else
      {
        consumingCompletion.SetResult();
      }

      TaskCompletionSource producingCompletion = new();

      if (Sendings != null)
      {
        Task.Run(
          () => Produce(Sendings, channel, producingCompletion, shutdownCompletion, cancellationToken),
          cancellationToken);
      }
      else
      {
        producingCompletion.SetResult();
      }

      return Task.WhenAll(consumingCompletion.Task, producingCompletion.Task);
    }

    Task.Run(() => Connect(connectionCompletion, FuncToExecute, cancellationToken), cancellationToken);

    return connectionCompletion.Task;
  }

  /// <summary>
  /// Получить.
  /// </summary>  
  /// <param name="receiving">Получение.</param>
  /// <param name="channel">Канал.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  protected abstract Task Receive(MessageReceiving receiving, IChannel channel, CancellationToken cancellationToken);

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
    Channel<MessageReceiving> receivings,
    IChannel channel,
    TaskCompletionSource consumingCompletion,
    CancellationToken cancellationToken)
  {
    if (!consumingCompletion.Task.IsCompleted)
    {
      consumingCompletion.SetResult();
    }
    
    await foreach (var receiving in receivings.Reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
    {
      await Receive(receiving, channel, cancellationToken).ConfigureAwait(false);
    }
  }

  private async Task Produce(    
    Channel<MessageSending> sendings,
    IChannel channel,
    TaskCompletionSource producingCompletion,
    TaskCompletionSource shutdownCompletion,
    CancellationToken cancellationToken)
  {
    if (!producingCompletion.Task.IsCompleted)
    {
      producingCompletion.SetResult();
    }

    await foreach (var sending in sendings.Reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
    {
      var sendingTask = Send(sending, channel, cancellationToken);

      var completionTask = await Task.WhenAny(sendingTask, shutdownCompletion.Task).ConfigureAwait(false);

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
