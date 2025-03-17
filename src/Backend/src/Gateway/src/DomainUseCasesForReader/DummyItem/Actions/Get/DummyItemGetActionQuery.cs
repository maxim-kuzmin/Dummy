namespace Makc.Dummy.Gateway.DomainUseCasesForReader.DummyItem.Actions.Get;

/// <summary>
/// Запрос действия по получению фиктивного предмета.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record DummyItemGetActionQuery(string ObjectId) : IQuery<Result<DummyItemSingleDTO>>;
