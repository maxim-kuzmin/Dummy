namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.DummyItem.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="Query">Запрос.</param>
public record DummyItemGetListActionRequest(DummyItemPageQuery Query) : IQuery<Result<DummyItemListDTO>>;
