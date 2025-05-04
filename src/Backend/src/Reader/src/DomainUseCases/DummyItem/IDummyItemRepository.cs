namespace Makc.Dummy.Reader.DomainUseCases.DummyItem;

/// <summary>
/// Интерфейс репозитория фиктивного предмета.
/// </summary>
public interface IDummyItemRepository : IObjectRepository<DummyItemEntity>
{
  /// <summary>
  /// Подсчитать асинхронно.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Количество сущностей.</returns>
  Task<long> CountAsync(DummyItemPageQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить асинхронно.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Сущность.</returns>
  Task<DummyItemEntity?> GetAsync(DummyItemSingleQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Перечислить асинхронно.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список сущностей.</returns>
  Task<List<DummyItemEntity>> ListAsync(DummyItemListQuery query, CancellationToken cancellationToken);
}
