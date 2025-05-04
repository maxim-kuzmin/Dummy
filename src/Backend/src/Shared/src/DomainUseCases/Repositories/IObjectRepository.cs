namespace Makc.Dummy.Shared.DomainUseCases.Repositories;

/// <summary>
/// Интерфейс репозитория объекта.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
public interface IObjectRepository<TEntity> : IRepositoryBase<TEntity>
{
  /// <summary>
  /// Получить по идентификатору объекта асинхронно.
  /// </summary>
  /// <param name="objectId">Идентификатор объекта.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Запрошенная сущность.</returns>
  Task<TEntity?> GetByObjectIdAsync(string objectId, CancellationToken cancellationToken);
}
