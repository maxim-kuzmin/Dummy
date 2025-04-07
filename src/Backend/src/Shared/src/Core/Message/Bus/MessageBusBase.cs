namespace Makc.Dummy.Shared.Core.Message.Bus;

/// <summary>
/// Основа шины сообщений.
/// </summary>
/// <param name="_logger">Логгер.</param>
public abstract class MessageBusBase(ILogger _logger) : IMessageBus
{
  private bool _isInited = false;

  private bool _isShutdown = false;

  private readonly Lock _lock = new();

  private readonly List<MessageReceiving> _receivings = [];

  /// <summary>
  /// Канал получателей.
  /// </summary>
  protected Channel<MessageReceiving>? ReceivingChannel { get; private set; }

  /// <summary>
  /// Канал отправителей.
  /// </summary>
  protected Channel<MessageSending>? SendingChannel { get; private set; }

  /// <summary>
  /// Инициализировать.
  /// </summary>
  /// <param name="direction">Направление.</param>
  /// <returns>Если инициализация происходит повторно, то true, иначе - false.</returns>
  public bool Init(AppConfigOptionsMessageDirectionEnum direction)
  {
    lock (_lock)
    {
      if (_isInited)
      {
        return false;
      }

      bool shouldBeReceivingChannelCreated = direction == AppConfigOptionsMessageDirectionEnum.Consumer
        ||
        direction == AppConfigOptionsMessageDirectionEnum.Both;

      if (shouldBeReceivingChannelCreated)
      {
        ReceivingChannel = CreateChannel<MessageReceiving>();
      }

      bool shouldBeSendingChannelCreated = direction == AppConfigOptionsMessageDirectionEnum.Producer
        ||
        direction == AppConfigOptionsMessageDirectionEnum.Both;

      if (shouldBeSendingChannelCreated)
      {
        SendingChannel = CreateChannel<MessageSending>();
      }

      _isInited = true;

      return true;
    }
  }

  /// <inheritdoc/>
  public abstract Task Connect(CancellationToken cancellationToken);

  /// <inheritdoc/>
  public ValueTask Publish(MessageSending sending, CancellationToken cancellationToken)
  {
    if (SendingChannel == null)
    {
      throw new NotImplementedException();
    }

    if (_isShutdown)
    {
      sending.Cancel(cancellationToken);

      return ValueTask.FromCanceled(cancellationToken);
    }
    else
    {
      return SendingChannel.Writer.WriteAsync(sending, cancellationToken);
    }
  }

  /// <inheritdoc/>
  public ValueTask Subscribe(MessageReceiving receiving, CancellationToken cancellationToken)
  {
    if (ReceivingChannel == null)
    {
      throw new NotImplementedException();
    }

    _receivings.Add(receiving);

    if (_isShutdown)
    {
      return ValueTask.FromCanceled(cancellationToken);
    }
    else
    {
      return ReceivingChannel.Writer.WriteAsync(receiving, cancellationToken);
    }
  }

  /// <summary>
  /// Проверить отключение.
  /// </summary>
  /// <param name="shutdownCompletion">Завершение отключения.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Если отключено, то true, иначе - false.</returns>
  protected bool CheckShutdown(TaskCompletionSource shutdownCompletion, CancellationToken cancellationToken)
  {
    if (_isShutdown)
    {
      return true;
    }

    if (cancellationToken.IsCancellationRequested)
    {
      Shutdown(shutdownCompletion);
    }

    return shutdownCompletion.Task.IsCompleted;
  }

  /// <summary>
  /// Сбросить выключение.
  /// </summary>
  protected void ResetShutdown()
  {
    _logger.LogDebug("MAKC:Reset:Start");

    if (ReceivingChannel != null)
    {
      foreach (var receiving in _receivings)
      {
        if (ReceivingChannel.Writer.TryWrite(receiving))
        {
          _logger.LogDebug("MAKC:Reset:Receiving:{sender}:Success", receiving.Sender);
        }
        else
        {
          _logger.LogDebug("MAKC:Reset:Receiving:{sender}:Failed", receiving.Sender);
        }
      }
    }

    _isShutdown = false;

    //lock (_lock)
    //{
    //  if (SendingChannel != null)
    //  {
    //    SendingChannel = CreateChannel<MessageSending>();

    //    _logger.LogDebug("MAKC:Reset:SendingChannel");
    //  }

    //  if (ReceivingChannel != null)
    //  {
    //    ReceivingChannel = CreateChannel<MessageReceiving>();

    //    _logger.LogDebug("MAKC:Reset:ReceivingChannel");

    //    foreach (var receiving in _receivings)
    //    {
    //      if (ReceivingChannel.Writer.TryWrite(receiving))
    //      {
    //        _logger.LogDebug("MAKC:Reset:Receiving:{sender}:Success", receiving.Sender);
    //      }
    //      else
    //      {
    //        _logger.LogDebug("MAKC:Reset:Receiving:{sender}:Failed", receiving.Sender);
    //      }
    //    }
    //  }      
    //}

    _logger.LogDebug("MAKC:Reset:End");
  }

  /// <summary>
  /// Отключить.
  /// </summary>
  /// <param name="shutdownCompletion">Завершение отключения.</param>
  protected void Shutdown(TaskCompletionSource shutdownCompletion)
  {
    _isShutdown = true;

    if (!shutdownCompletion.Task.IsCompleted)
    {
      shutdownCompletion.SetResult();
    }
  }

  private static Channel<T> CreateChannel<T>()
  {
    return Channel.CreateUnbounded<T>(new()
    {
      SingleWriter = false,
      SingleReader = false,
      AllowSynchronousContinuations = true
    });
  }
}

