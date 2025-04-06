namespace Makc.Dummy.Shared.Infrastructure.Kafka.Message;

/// <summary>
/// Шина сообщений.
/// </summary>
public abstract class MessageBus : MessageBusBase
{
  /// <inheritdoc/>
  public override Task Connect(CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
