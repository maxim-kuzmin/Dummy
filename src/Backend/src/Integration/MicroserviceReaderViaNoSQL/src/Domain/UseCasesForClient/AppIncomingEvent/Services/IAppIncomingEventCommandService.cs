namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCasesForClient.AppIncomingEvent.Services;

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
  Task<Result> Delete(
    AppIncomingEventDeleteCommand command,
    CancellationToken cancellationToken);

  /// <summary>
  /// Сохранить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AppIncomingEventSingleDTO>> Save(
    AppIncomingEventSaveCommand command,
    CancellationToken cancellationToken);
}
