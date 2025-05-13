namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEventPayload.Services;

/// <summary>
/// Интерфейс сервиса запросов полезной нагрузки исходящего события приложения.
/// </summary>
public interface IAppOutgoingEventPayloadQueryService
{
  /// <summary>
  /// Получить количество сущностей.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Количество сущностей.</returns>
  Task<long> GetCount(AppOutgoingEventPayloadPageQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить единственную сущность.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Сущность.</returns>
  Task<AppOutgoingEventPayloadSingleDTO?> GetSingle(
    AppOutgoingEventPayloadSingleQuery query,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить список сущностей.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список сущностей.</returns>
  Task<List<AppOutgoingEventPayloadSingleDTO>> GetList(
    AppOutgoingEventPayloadListQuery query,
    CancellationToken cancellationToken);
}
