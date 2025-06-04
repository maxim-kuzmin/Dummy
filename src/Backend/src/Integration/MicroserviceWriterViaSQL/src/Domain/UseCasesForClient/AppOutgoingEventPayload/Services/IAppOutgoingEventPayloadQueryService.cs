namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCasesForClient.AppOutgoingEventPayload.Services;

/// <summary>
/// Интерфейс сервиса запросов полезной нагрузки исходящего события приложения.
/// </summary>
public interface IAppOutgoingEventPayloadQueryService
{
  /// <summary>
  /// Получить список объектов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<List<AppOutgoingEventPayloadSingleDTO>>> GetList(
    AppOutgoingEventPayloadListQuery query,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить страницу объектов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AppOutgoingEventPayloadPageDTO>> GetPage(
    AppOutgoingEventPayloadPageQuery query,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить единственный объект.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AppOutgoingEventPayloadSingleDTO>> GetSingle(
    AppOutgoingEventPayloadSingleQuery query,
    CancellationToken cancellationToken);
}
