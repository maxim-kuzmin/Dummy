namespace Makc.Dummy.Shared.Core.Message.Bus;

/// <summary>
/// Основа шины сообщений.
/// </summary>
public abstract class MessageBusBase : IMessageBus
{
  private bool _isInited = false;

  private readonly Lock _lock = new();

  /// <summary>
  /// Получатели.
  /// </summary>
  protected Channel<MessageReceiving>? Receivings { get; private set; }

  /// <summary>
  /// Отправители.
  /// </summary>
  protected Channel<MessageSending>? Sendings { get; private set; }

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

      bool shouldBeReceivingsCreated = direction == AppConfigOptionsMessageDirectionEnum.Consumer
        ||
        direction == AppConfigOptionsMessageDirectionEnum.Both;

      if (shouldBeReceivingsCreated)
      {
        Receivings = Channel.CreateUnbounded<MessageReceiving>(new()
        {
          SingleWriter = false,
          SingleReader = false,
          AllowSynchronousContinuations = true
        });
      }

      bool shouldBeSendingsCreated = direction == AppConfigOptionsMessageDirectionEnum.Producer
        ||
        direction == AppConfigOptionsMessageDirectionEnum.Both;

      if (shouldBeSendingsCreated)
      {
        Sendings = Channel.CreateUnbounded<MessageSending>(new()
        {
          SingleWriter = false,
          SingleReader = false,
          AllowSynchronousContinuations = true
        });
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
    if (Sendings == null)
    {
      throw new NotImplementedException();
    }

    return Sendings.Writer.WriteAsync(sending, cancellationToken);
  }

  /// <inheritdoc/>
  public ValueTask Subscribe(MessageReceiving receiving, CancellationToken cancellationToken)
  {
    if (Receivings == null)
    {
      throw new NotImplementedException();
    }

    return Receivings.Writer.WriteAsync(receiving, cancellationToken);
  }
}

