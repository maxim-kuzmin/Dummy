namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCases.AppIncomingEvent.Services;

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
  /// Сохранить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<AppCommandResultWithValue<AppIncomingEventSingleDTO>> Save(
    AppIncomingEventSaveCommand command,
    CancellationToken cancellationToken);
}
