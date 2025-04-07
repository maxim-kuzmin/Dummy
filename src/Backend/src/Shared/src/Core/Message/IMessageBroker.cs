namespace Makc.Dummy.Shared.Core.Message;

/// <summary>
/// Интерфейс брокера сообщений.
/// </summary>
public interface IMessageBroker : IMessageConsumer, IMessageProducer
{
  /// <summary>
  /// Соединиться.
  /// </summary>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task Connect(CancellationToken cancellationToken);
}
