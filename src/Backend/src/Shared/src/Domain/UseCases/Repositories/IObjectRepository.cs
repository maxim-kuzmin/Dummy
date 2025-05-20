namespace Makc.Dummy.Shared.Domain.UseCases.Repositories;

/// <summary>
/// Интерфейс репозитория объекта.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
public interface IObjectRepository<TEntity> : IRepositoryBase<TEntity>
{
  /// <summary>
  /// Получить по идентификатору объекта.
  /// </summary>
  /// <param name="objectId">Идентификатор объекта.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Запрошенная сущность.</returns>
  Task<TEntity?> GetByObjectId(string objectId, CancellationToken cancellationToken);
}
