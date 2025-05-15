namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.DummyItem.Services;

/// <summary>
/// Интерфейс сервиса запросов фиктивного предмета.
/// </summary>
public interface IDummyItemQueryService
{
  /// <summary>
  /// Подсчитать.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Количество сущностей.</returns>
  Task<long> Count(DummyItemPageQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Объект передачи данных.</returns>
  Task<DummyItemSingleDTO?> Get(DummyItemSingleQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Перечислить.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список объектов передачи данных.</returns>
  Task<List<DummyItemSingleDTO>> List(DummyItemListQuery query, CancellationToken cancellationToken);
}
