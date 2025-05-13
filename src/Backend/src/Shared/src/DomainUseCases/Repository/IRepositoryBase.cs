namespace Makc.Dummy.Shared.DomainUseCases.Repository;

/// <summary>
/// Интерфейс основы репозитория.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
public interface IRepositoryBase<TEntity>
{
  /// <summary>
  /// Добавить.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Добавленная сущность.</returns>
  Task<TEntity> Add(TEntity entity, CancellationToken cancellationToken);

  /// <summary>
  /// Удалить.
  /// </summary>
  /// <param name="entity">Удаляемая сущность.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task Delete(TEntity entity, CancellationToken cancellationToken);

  /// <summary>
  /// Обновить.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task Update(TEntity entity, CancellationToken cancellationToken);
}
