namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEventPayload.Services;

/// <summary>
/// Интерфейс сервиса команд полезной нагрузки исходящего события приложения.
/// </summary>
public interface IAppOutgoingEventPayloadCommandService
{
  /// <summary>
  /// Удалить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<AppCommandResultWithoutValue> Delete(
    AppOutgoingEventPayloadDeleteActionCommand command,
    CancellationToken cancellationToken);

  /// <summary>
  /// Сохранить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<AppCommandResultWithValue<AppOutgoingEventPayloadSingleDTO>> Save(
    AppOutgoingEventPayloadSaveActionCommand command,
    CancellationToken cancellationToken);
}
