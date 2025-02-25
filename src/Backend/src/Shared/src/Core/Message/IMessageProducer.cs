namespace Makc.Dummy.Shared.Core.Message;

/// <summary>
/// Интерфейс поставщика сообщений.
/// </summary>
public interface IMessageProducer
{
  /// <summary>
  /// Опубликовать.
  /// </summary>
  /// <param name="source">Источник.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  ValueTask Publish(MessageSending source, CancellationToken cancellationToken);

  /// <summary>
  /// Начать.
  /// </summary>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task Start(CancellationToken cancellationToken);
}
