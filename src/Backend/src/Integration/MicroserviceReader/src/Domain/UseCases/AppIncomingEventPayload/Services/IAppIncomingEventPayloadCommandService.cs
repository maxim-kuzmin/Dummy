namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCases.AppIncomingEventPayload.Services;

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
  Task<Result> Delete(
    AppIncomingEventPayloadDeleteCommand command,
    CancellationToken cancellationToken);

  /// <summary>
  /// Сохранить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AppIncomingEventPayloadSingleDTO>> Save(
    AppIncomingEventPayloadSaveCommand command,
    CancellationToken cancellationToken);
}
