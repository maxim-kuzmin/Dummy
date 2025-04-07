namespace Makc.Dummy.Shared.Core.Message;

/// <summary>
/// Интерфейс потребителя сообщений.
/// </summary>
public interface IMessageConsumer
{
  /// <summary>
  /// Подписаться.
  /// </summary>
  /// <param name="receiving">Получение.</param>
  /// <param name="cancellationToken"></param>
  /// <returns>Задача.</returns>
  public ValueTask Subscribe(MessageReceiving receiving, CancellationToken cancellationToken);
}
