namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCasesForClient.AppIncomingEventPayload.Services;

/// <summary>
/// Интерфейс сервиса запросов полезной нагрузки входящего события приложения.
/// </summary>
public interface IAppIncomingEventPayloadQueryService
{
  /// <summary>
  /// Получить список объектов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<List<AppIncomingEventPayloadSingleDTO>>> GetList(
    AppIncomingEventPayloadListQuery query,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить страницу объектов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список объектов.</returns>
  Task<Result<AppIncomingEventPayloadPageDTO>> GetPage(
    AppIncomingEventPayloadPageQuery query,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить единственный объект.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Объект.</returns>
  Task<Result<AppIncomingEventPayloadSingleDTO>> GetSingle(
    AppIncomingEventPayloadSingleQuery query,
    CancellationToken cancellationToken);
}
