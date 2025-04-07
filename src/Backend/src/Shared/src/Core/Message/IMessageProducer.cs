namespace Makc.Dummy.Shared.Core.Message;

/// <summary>
/// Интерфейс поставщика сообщений.
/// </summary>
public interface IMessageProducer
{
  /// <summary>
  /// Опубликовать.
  /// </summary>
  /// <param name="sending">Отправка.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  ValueTask Publish(MessageSending sending, CancellationToken cancellationToken);
}
