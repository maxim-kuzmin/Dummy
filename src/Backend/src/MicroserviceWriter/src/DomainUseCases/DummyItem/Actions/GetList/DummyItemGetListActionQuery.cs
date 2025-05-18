namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.DummyItem.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="Query">Запрос страницы.</param>
public record DummyItemGetListActionQuery(DummyItemPageQuery Query) : IQuery<Result<DummyItemListDTO>>;
