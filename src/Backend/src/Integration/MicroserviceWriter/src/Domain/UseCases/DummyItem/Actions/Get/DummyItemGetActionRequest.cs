namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.DummyItem.Actions.Get;

/// <summary>
/// Запрос действия по получению фиктивного предмета.
/// </summary>
/// <param name="Query">Запрос.</param>
public record DummyItemGetActionRequest(DummyItemSingleQuery Query) :
  IQuery<Result<DummyItemSingleDTO>>;
