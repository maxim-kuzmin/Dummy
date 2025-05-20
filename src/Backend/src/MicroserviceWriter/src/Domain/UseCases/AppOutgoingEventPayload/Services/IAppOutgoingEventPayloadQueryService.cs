namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutgoingEventPayload.Services;

/// <summary>
/// Интерфейс сервиса запросов полезной нагрузки исходящего события приложения.
/// </summary>
public interface IAppOutgoingEventPayloadQueryService
{
  /// <summary>
  /// Получить количество объектов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Количество объектов.</returns>
  Task<long> GetCount(AppOutgoingEventPayloadCountQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить список объектов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список объектов.</returns>
  Task<List<AppOutgoingEventPayloadSingleDTO>> GetList(
    AppOutgoingEventPayloadListQuery query,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить страницу объектов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Страница объектов.</returns>
  Task<AppOutgoingEventPayloadListDTO> GetPage(
    AppOutgoingEventPayloadPageQuery query,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить единственный объект.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Объект.</returns>
  Task<AppOutgoingEventPayloadSingleDTO?> GetSingle(
    AppOutgoingEventPayloadSingleQuery query,
    CancellationToken cancellationToken);
}
