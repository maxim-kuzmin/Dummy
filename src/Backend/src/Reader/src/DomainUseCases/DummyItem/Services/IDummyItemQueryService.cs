namespace Makc.Dummy.Reader.DomainUseCases.DummyItem.Services;

/// <summary>
/// Интерфейс сервиса запросов фиктивного предмета.
/// </summary>
public interface IDummyItemQueryService
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
  /// <returns>Объект передачи данных.</returns>
  Task<DummyItemSingleDTO?> GetAsync(DummyItemSingleQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Перечислить асинхронно.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список объектов передачи данных.</returns>
  Task<List<DummyItemSingleDTO>> ListAsync(DummyItemListQuery query, CancellationToken cancellationToken);
}
