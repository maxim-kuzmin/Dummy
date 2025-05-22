namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCases.AppIncomingEventPayload.Services;

/// <summary>
/// Интерфейс сервиса запросов полезной нагрузки входящего события приложения.
/// </summary>
public interface IAppIncomingEventPayloadQueryService
{
  /// <summary>
  /// Скачать.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Объект списка.</returns>
  Task<AppIncomingEventPayloadPageDTO> Download(
      AppIncomingEventPayloadDownloadQuery query,
      CancellationToken cancellationToken);

  /// <summary>
  /// Получить количество объектов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Количество объектов.</returns>
  Task<long> GetCount(AppIncomingEventPayloadCountQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить список объектов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список объектов.</returns>
  Task<List<AppIncomingEventPayloadSingleDTO>> GetList(
    AppIncomingEventPayloadListQuery query,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить страницу объектов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список объектов.</returns>
  Task<AppIncomingEventPayloadPageDTO> GetPage(
    AppIncomingEventPayloadPageQuery query,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить единственный объект.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Объект.</returns>
  Task<AppIncomingEventPayloadSingleDTO?> GetSingle(
    AppIncomingEventPayloadSingleQuery query,
    CancellationToken cancellationToken);
}
