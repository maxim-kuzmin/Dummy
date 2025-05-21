namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent.Services;

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
  Task<Result> Delete(
    AppOutgoingEventDeleteCommand command,
    CancellationToken cancellationToken);

  /// <summary>
  /// Сохранить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AppOutgoingEventSingleDTO>> Save(
    AppOutgoingEventSaveCommand command,
    CancellationToken cancellationToken);
}
