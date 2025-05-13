namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEventPayload.Services;

/// <summary>
/// Интерфейс сервиса запросов полезной нагрузки входящего события приложения.
/// </summary>
public interface IAppIncomingEventPayloadQueryService
{
  /// <summary>
  /// Получить количество сущностей.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Количество сущностей.</returns>
  Task<long> GetCount(AppIncomingEventPayloadPageQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить единственную сущность.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Сущность.</returns>
  Task<AppIncomingEventPayloadSingleDTO?> GetSingle(
    AppIncomingEventPayloadSingleQuery query,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить список сущностей.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список сущностей.</returns>
  Task<List<AppIncomingEventPayloadSingleDTO>> GetList(
    AppIncomingEventPayloadListQuery query,
    CancellationToken cancellationToken);
}
