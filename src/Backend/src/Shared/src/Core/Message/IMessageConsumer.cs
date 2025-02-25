namespace Makc.Dummy.Shared.Core.Message;

/// <summary>
/// Интерфейс потребителя сообщений.
/// </summary>
public interface IMessageConsumer
{
  /// <summary>
  /// Начать.
  /// </summary>
  /// <param name="receivings">Получения.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task Start(IEnumerable<MessageReceiving> receivings, CancellationToken cancellationToken);
}
