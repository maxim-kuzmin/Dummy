namespace Makc.Dummy.Gateway.DomainUseCasesForReader.DummyItem.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="Page">Страница.</param>
/// <param name="Sort">Сортировка.</param>
/// <param name="Filter">Фильтр.</param>
public record DummyItemGetListActionQuery(
  QueryPageSection Page,
  QuerySortSection Sort,
  DummyItemGetListActionQueryFilter Filter) : IQuery<Result<DummyItemListDTO>>;
