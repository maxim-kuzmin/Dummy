namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.Services;

/// <summary>
/// Интерфейс сервиса команд исходящего события приложения.
/// </summary>
public interface IAppOutgoingEventCommandService
{
  /// <summary>
  /// Удалить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<AppCommandResultWithoutValue> Delete(
    AppOutgoingEventDeleteActionCommand command,
    CancellationToken cancellationToken);

  /// <summary>
  /// Сохранить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<AppCommandResultWithValue<AppOutgoingEventSingleDTO>> Save(
    AppOutgoingEventSaveActionCommand command,
    CancellationToken cancellationToken);
}
