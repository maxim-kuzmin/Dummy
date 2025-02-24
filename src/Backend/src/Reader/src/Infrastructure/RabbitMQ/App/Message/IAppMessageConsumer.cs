namespace Makc.Dummy.Reader.Infrastructure.RabbitMQ.App.Message;

/// <summary>
/// Интерфейс потребителя сообщений приложения.
/// </summary>
public interface IAppMessageConsumer
{
  /// <summary>
  /// Начать.
  /// </summary>
  /// <param name="receivings">Получения.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task Start(IEnumerable<AppMessageReceiving> receivings, CancellationToken cancellationToken);
}
