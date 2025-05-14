namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEvent;

/// <summary>
/// Интерфейс репозитория входящего события приложения.
/// </summary>
public interface IAppIncomingEventRepository : IObjectRepository<AppIncomingEventEntity>
{
  /// <summary>
  /// Добавить, если не существует по идентификатору и имени события.
  /// </summary>
  /// <param name="entities">Сущности.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task AddIfNotExistsByEventIdAndName(
    IEnumerable<AppIncomingEventEntity> entities,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить количество сущностей.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Количество сущностей.</returns>
  Task<long> GetCount(AppIncomingEventPageQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить единственную сущность.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Сущность.</returns>
  Task<AppIncomingEventEntity?> GetSingle(AppIncomingEventSingleQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить список сущностей.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список сущностей.</returns>
  Task<List<AppIncomingEventEntity>> GetList(AppIncomingEventListQuery query, CancellationToken cancellationToken);
}
