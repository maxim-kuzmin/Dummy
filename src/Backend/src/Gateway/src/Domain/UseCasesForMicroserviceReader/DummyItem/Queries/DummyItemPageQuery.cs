namespace Makc.Dummy.Gateway.Domain.UseCasesForMicroserviceReader.DummyItem.Queries;

/// <summary>
/// Запрос страницы фиктивных предметов.
/// </summary>
/// <param name="Page">Страница.</param>
/// <param name="Sort">Сортировка.</param>
/// <param name="Filter">Фильтр.</param>
public record DummyItemPageQuery(
  QueryPageSection? Page,
  QuerySortSection? Sort,
  DummyItemQueryFilterSection? Filter) :
  DummyItemListQuery(Sort, Filter);
