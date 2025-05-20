namespace Makc.Dummy.Gateway.Domain.UseCasesForMicroserviceReader.DummyItem.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="PageQuery">Запрос страницы.</param>
public record DummyItemGetListActionQuery(DummyItemPageQuery PageQuery) :
  DummyItemListQuery(PageQuery),
  IQuery<Result<DummyItemListDTO>>;
