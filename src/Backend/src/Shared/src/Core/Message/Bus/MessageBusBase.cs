namespace Makc.Dummy.Shared.Core.Message.Bus;

/// <summary>
/// Основа шины сообщений.
/// </summary>
public abstract class MessageBusBase : IMessageBus
{
  /// <summary>
  /// Получатели.
  /// </summary>
  protected Channel<MessageReceiving> Receivings { get; } = Channel.CreateUnbounded<MessageReceiving>(new()
  {
    SingleWriter = false,
    SingleReader = false,
    AllowSynchronousContinuations = true
  });

  /// <summary>
  /// Отправители.
  /// </summary>
  protected Channel<MessageSending> Sendings { get; } = Channel.CreateUnbounded<MessageSending>(new()
  {
    SingleWriter = false,
    SingleReader = false,
    AllowSynchronousContinuations = true
  });

  /// <inheritdoc/>
  public abstract Task Connect(CancellationToken cancellationToken);

  /// <inheritdoc/>
  public ValueTask Publish(MessageSending sending, CancellationToken cancellationToken)
  {
    return Sendings.Writer.WriteAsync(sending, cancellationToken);
  }

  /// <inheritdoc/>
  public ValueTask Subscribe(MessageReceiving receiving, CancellationToken cancellationToken)
  {
    return Receivings.Writer.WriteAsync(receiving, cancellationToken);
  }
}

