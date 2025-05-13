namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.Services;

/// <summary>
/// Интерфейс сервиса запросов исходящего события приложения.
/// </summary>
public interface IAppOutgoingEventQueryService
{
  /// <summary>
  /// Получить количество сущностей.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Количество сущностей.</returns>
  Task<long> GetCount(AppOutgoingEventPageQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить единственную сущность.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Сущность.</returns>
  Task<AppOutgoingEventSingleDTO?> GetSingle(AppOutgoingEventSingleQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить список сущностей.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список сущностей.</returns>
  Task<List<AppOutgoingEventSingleDTO>> GetList(AppOutgoingEventListQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить список идентификаторов неопубликованных сущностей.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список идентификаторов.</returns>
  Task<List<long>> GetUnpublishedIdList(
    AppOutgoingEventUnpublishedListQuery query,
    CancellationToken cancellationToken);
}
