namespace Makc.Dummy.MicroserviceReader.DomainUseCases.DummyItem.Queries;

/// <summary>
/// Запрос списка фиктивных предметов.
/// </summary>
/// <param name="Sort">Сортировка.</param>
/// <param name="Filter">Фильтр.</param>
public record DummyItemListQuery(
  QuerySortSection? Sort,
  DummyItemQueryFilterSection? Filter) :
  DummyItemCountQuery(Filter);
