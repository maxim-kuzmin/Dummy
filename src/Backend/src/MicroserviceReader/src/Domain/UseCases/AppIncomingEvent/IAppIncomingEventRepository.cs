namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEvent;

/// <summary>
/// Интерфейс репозитория входящего события приложения.
/// </summary>
public interface IAppIncomingEventRepository : IObjectRepository<AppIncomingEventEntity>
{
  /// <summary>
  /// Добавить не найденное по событию.
  /// </summary>
  /// <param name="entities">Сущности.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task AddNotFoundByEvent(IEnumerable<AppIncomingEventEntity> entities, CancellationToken cancellationToken);

  /// <summary>
  /// Получить идентификаторы обработанных сущностей.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список идентификаторов.</returns>
  Task<List<string>> GetProcessedIds(AppIncomingEventProcessedListQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить количество сущностей.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Количество сущностей.</returns>
  Task<long> GetCount(AppIncomingEventCountQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить список сущностей.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список сущностей.</returns>
  Task<List<AppIncomingEventEntity>> GetList(AppIncomingEventListQuery query, CancellationToken cancellationToken);
  
  /// <summary>
  /// Получить элементы страницы.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список сущностей.</returns>
  Task<List<AppIncomingEventEntity>> GetPageItems(
    AppIncomingEventPageQuery query,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить единственную сущность.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Сущность.</returns>
  Task<AppIncomingEventEntity?> GetSingle(AppIncomingEventSingleQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить список незагруженных сущностей.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список сущностей.</returns>
  Task<List<AppIncomingEventEntity>> GetUnloadedList(
    AppIncomingEventNamedListQuery query,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить список необработанных сущностей.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список сущностей.</returns>
  Task<List<AppIncomingEventEntity>> GetUnprocessedList(
    AppIncomingEventNamedListQuery query,
    CancellationToken cancellationToken);
}
