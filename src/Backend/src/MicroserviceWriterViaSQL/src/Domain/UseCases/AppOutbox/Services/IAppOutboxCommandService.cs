namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.UseCases.AppOutbox.Services;

/// <summary>
/// Сервис исходящего сообщения приложения.
/// </summary>
public interface IAppOutboxCommandService
{
  /// <summary>
  /// Очистить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task Clear(AppOutboxClearCommand command, CancellationToken cancellationToken);

  /// <summary>
  /// Выдать.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task Produce(AppOutboxProduceCommand command, CancellationToken cancellationToken);

  /// <summary>
  /// Сохранить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<AppCommandResultWithoutValue> Save(AppOutboxSaveCommand command, CancellationToken cancellationToken);
}
