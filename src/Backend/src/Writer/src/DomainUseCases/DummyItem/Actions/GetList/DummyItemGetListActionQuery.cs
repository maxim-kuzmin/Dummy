namespace Makc.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="CountQuery">Запрос количества.</param>
public record DummyItemGetListActionQuery(DummyItemCountQuery CountQuery) :
  DummyItemListQuery(CountQuery),
  IQuery<Result<DummyItemListDTO>>;
