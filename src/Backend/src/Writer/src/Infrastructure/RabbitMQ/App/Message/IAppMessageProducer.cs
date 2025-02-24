namespace Makc.Dummy.Writer.Infrastructure.RabbitMQ.App.Message;

/// <summary>
/// Интерфейс поставщика сообщений приложения.
/// </summary>
public interface IAppMessageProducer
{
  /// <summary>
  /// Опубликовать.
  /// </summary>
  /// <param name="source">Источник.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  ValueTask Publish(AppMessageSource source, CancellationToken cancellationToken);

  /// <summary>
  /// Начать.
  /// </summary>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task Start(CancellationToken cancellationToken);
}
