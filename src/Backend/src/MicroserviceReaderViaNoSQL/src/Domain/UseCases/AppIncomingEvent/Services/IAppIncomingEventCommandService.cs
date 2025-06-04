namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent.Services;

/// <summary>
/// Интерфейс сервиса команд входящего события приложения.
/// </summary>
public interface IAppIncomingEventCommandService
{
  /// <summary>
  /// Удалить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<AppCommandResultWithoutValue> Delete(
    AppIncomingEventDeleteCommand command,
    CancellationToken cancellationToken);

  /// <summary>
  /// Удалить список.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result> DeleteList(AppIncomingEventDeleteListCommand command, CancellationToken cancellationToken);

  /// <summary>
  /// Вставить список.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result> InsertList(AppIncomingEventInsertListCommand command, CancellationToken cancellationToken);

  /// <summary>
  /// Сохранить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<AppCommandResultWithValue<AppIncomingEventSingleDTO>> Save(
    AppIncomingEventSaveCommand command,
    CancellationToken cancellationToken);
}
