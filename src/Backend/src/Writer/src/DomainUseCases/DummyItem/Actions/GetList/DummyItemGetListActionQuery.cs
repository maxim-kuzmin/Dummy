namespace Makc.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="PageQuery">Запрос страницы.</param>
public record DummyItemGetListActionQuery(DummyItemPageQuery PageQuery) :
  DummyItemListQuery(PageQuery),
  IQuery<Result<DummyItemListDTO>>;
