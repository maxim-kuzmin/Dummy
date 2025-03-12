namespace Makc.Dummy.Reader.DomainUseCases.DummyItem;

/// <summary>
/// Интерфейс репозитория фиктивного предмета.
/// </summary>
public interface IDummyItemRepository
{
  /// <summary>
  /// Добавить асинхронно.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Добавленная сущность.</returns>
  Task<DummyItemEntity> AddAsync(DummyItemEntity entity, CancellationToken cancellationToken);

  /// <summary>
  /// Удалить асинхронно.
  /// </summary>
  /// <param name="entity">Удаляемая сущность.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task DeleteAsync(DummyItemEntity entity, CancellationToken cancellationToken);

  /// <summary>
  /// Получить по идентификатору объекта асинхронно.
  /// </summary>
  /// <param name="objectId">Идентификатор объекта.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Запрошенная сущность.</returns>
  Task<DummyItemEntity> GetByObjectIdAsync(string objectId, CancellationToken cancellationToken);

  /// <summary>
  /// Обновить асинхронно.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task UpdateAsync(DummyItemEntity entity, CancellationToken cancellationToken);
}
