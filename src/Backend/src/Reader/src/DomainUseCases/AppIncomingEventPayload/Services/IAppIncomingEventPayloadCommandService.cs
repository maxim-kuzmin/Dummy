namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEventPayload.Services;

/// <summary>
/// Интерфейс сервиса команд полезной нагрузки входящего события приложения.
/// </summary>
public interface IAppIncomingEventPayloadCommandService
{
  /// <summary>
  /// Удалить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<AppCommandResultWithoutValue> Delete(
    AppIncomingEventPayloadDeleteActionCommand command,
    CancellationToken cancellationToken);

  /// <summary>
  /// Сохранить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<AppCommandResultWithValue<AppIncomingEventPayloadSingleDTO>> Save(
    AppIncomingEventPayloadSaveActionCommand command,
    CancellationToken cancellationToken);
}
