namespace Makc.Dummy.MicroserviceReader.DomainUseCases.DummyItem.Actions.Get;

/// <summary>
/// Запрос действия по получению фиктивного предмета.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record DummyItemGetActionQuery(string? ObjectId) :
  DummyItemSingleQuery(ObjectId),
  IQuery<Result<DummyItemSingleDTO>>;
