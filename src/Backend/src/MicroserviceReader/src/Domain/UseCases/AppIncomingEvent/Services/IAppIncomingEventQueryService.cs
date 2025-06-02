namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEvent.Services;

/// <summary>
/// Интерфейс сервиса запросов входящего события приложения.
/// </summary>
public interface IAppIncomingEventQueryService
{
  /// <summary>
  /// Получить количество объектов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Количество объектов.</returns>
  Task<long> GetCount(AppIncomingEventCountQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить список объектов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список объектов.</returns>
  Task<List<AppIncomingEventSingleDTO>> GetList(AppIncomingEventListQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить страницу объектов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список объектов.</returns>
  Task<AppIncomingEventPageDTO> GetPage(AppIncomingEventPageQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить идентификаторы обработанных объектов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Идентификаторы объектов.</returns>
  Task<List<string>> GetProcessedIds(AppIncomingEventProcessedListQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить единственный объект.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Объект.</returns>
  Task<AppIncomingEventSingleDTO?> GetSingle(AppIncomingEventSingleQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить список незагруженных объектов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список объектов.</returns>
  Task<List<AppIncomingEventSingleDTO>> GetUnloadedList(
      AppIncomingEventNamedListQuery query,
      CancellationToken cancellationToken);

  /// <summary>
  /// Получить список необработанных объектов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список объектов.</returns>
  Task<List<AppIncomingEventSingleDTO>> GetUnprocessedList(
      AppIncomingEventNamedListQuery query,
      CancellationToken cancellationToken);
}
