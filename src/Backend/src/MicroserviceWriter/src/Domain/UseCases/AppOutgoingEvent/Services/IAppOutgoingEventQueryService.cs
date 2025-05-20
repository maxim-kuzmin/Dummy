namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent.Services;

/// <summary>
/// Интерфейс сервиса запросов исходящего события приложения.
/// </summary>
public interface IAppOutgoingEventQueryService
{
  /// <summary>
  /// Получить количество объектов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Количество объектов.</returns>
  Task<long> GetCount(AppOutgoingEventCountQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить список объектов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список объектов.</returns>
  Task<List<AppOutgoingEventSingleDTO>> GetList(AppOutgoingEventListQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить страницу объектов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список объектов.</returns>
  Task<AppOutgoingEventPageDTO> GetPage(AppOutgoingEventPageQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить единственный объект.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Объект.</returns>
  Task<AppOutgoingEventSingleDTO?> GetSingle(AppOutgoingEventSingleQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить список неопубликованных идентификаторов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список неопубликованных идентификаторов.</returns>
  Task<List<long>> GetUnpublishedIdList(
    AppOutgoingEventUnpublishedListQuery query,
    CancellationToken cancellationToken);
}
