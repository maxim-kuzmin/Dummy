namespace Makc.Dummy.Gateway.DomainUseCases.DummyItem.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="Page">Страница.</param>
/// <param name="Order">Порядок сортировки.</param>
/// <param name="Filter">Фильтр.</param>
public record DummyItemGetListActionQuery(
  QueryPageSection Page,
  QueryOrderSection Order,
  DummyItemGetListActionQueryFilter Filter) : IQuery<Result<DummyItemListDTO>>;
