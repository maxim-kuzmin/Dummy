namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEvent;

/// <summary>
/// Интерфейс репозитория входящего события приложения.
/// </summary>
public interface IAppIncomingEventRepository : IEntityRepository<AppIncomingEventEntity>
{
  /// <summary>
  /// Подсчитать асинхронно.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Количество сущностей.</returns>
  Task<long> CountAsync(AppIncomingEventPageQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить асинхронно.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Сущность.</returns>
  Task<AppIncomingEventEntity?> GetAsync(AppIncomingEventSingleQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Перечислить асинхронно.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список сущностей.</returns>
  Task<List<AppIncomingEventEntity>> ListAsync(AppIncomingEventListQuery query, CancellationToken cancellationToken);
}
