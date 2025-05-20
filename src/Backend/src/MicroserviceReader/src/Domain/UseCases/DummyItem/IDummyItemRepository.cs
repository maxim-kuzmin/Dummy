namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.DummyItem;

/// <summary>
/// Интерфейс репозитория фиктивного предмета.
/// </summary>
public interface IDummyItemRepository : IObjectRepository<DummyItemEntity>
{
  /// <summary>
  /// Получить количество сущностей.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Количество сущностей.</returns>
  Task<long> GetCount(DummyItemCountQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить список сущностей.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список сущностей.</returns>
  Task<List<DummyItemEntity>> GetList(DummyItemListQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить элементы страницы.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список сущностей.</returns>
  Task<List<DummyItemEntity>> GetPageItems(DummyItemPageQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить единственную сущность.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Сущность.</returns>
  Task<DummyItemEntity?> GetSingle(DummyItemSingleQuery query, CancellationToken cancellationToken);
}
