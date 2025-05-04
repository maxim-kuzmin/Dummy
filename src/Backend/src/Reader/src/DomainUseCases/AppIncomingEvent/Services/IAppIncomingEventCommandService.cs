namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEvent.Services;

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
    AppIncomingEventDeleteActionCommand command,
    CancellationToken cancellationToken);

  /// <summary>
  /// Сохранить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<AppCommandResultWithValue<AppIncomingEventSingleDTO>> Save(
    AppIncomingEventSaveActionCommand command,
    CancellationToken cancellationToken);
}
