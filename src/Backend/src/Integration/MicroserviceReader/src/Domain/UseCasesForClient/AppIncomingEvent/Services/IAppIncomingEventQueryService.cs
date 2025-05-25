namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCasesForClient.AppIncomingEvent.Services;

/// <summary>
/// Интерфейс сервиса запросов входящего события приложения.
/// </summary>
public interface IAppIncomingEventQueryService
{
  /// <summary>
  /// Получить список объектов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<List<AppIncomingEventSingleDTO>>> GetList(
    AppIncomingEventListQuery query,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить страницу объектов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список объектов.</returns>
  Task<Result<AppIncomingEventPageDTO>> GetPage(
    AppIncomingEventPageQuery query,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить единственный объект.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Объект.</returns>
  Task<Result<AppIncomingEventSingleDTO>> GetSingle(
    AppIncomingEventSingleQuery query,
    CancellationToken cancellationToken);
}
