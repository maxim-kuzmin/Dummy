namespace Makc.Dummy.Shared.DomainUseCases.Repository;

/// <summary>
/// Интерфейс основы репозитория.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
public interface IRepositoryBase<TEntity>
{
  /// <summary>
  /// Добавить асинхронно.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Добавленная сущность.</returns>
  Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);

  /// <summary>
  /// Удалить асинхронно.
  /// </summary>
  /// <param name="entity">Удаляемая сущность.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);

  /// <summary>
  /// Обновить асинхронно.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
}
