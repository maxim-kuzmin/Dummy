namespace Makc.Dummy.Shared.Core.Message;

/// <summary>
/// Интерфейс шины сообщений.
/// </summary>
public interface IMessageBus
{
  /// <summary>
  /// Соединиться.
  /// </summary>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task Connect(CancellationToken cancellationToken);

  /// <summary>
  /// Опубликовать.
  /// </summary>
  /// <param name="sending">Отправка.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  ValueTask Publish(MessageSending sending, CancellationToken cancellationToken);

  /// <summary>
  /// Подписаться.
  /// </summary>
  /// <param name="receiving">Получение.</param>
  /// <param name="cancellationToken"></param>
  /// <returns>Задача.</returns>
  public ValueTask Subscribe(MessageReceiving receiving, CancellationToken cancellationToken);
}
