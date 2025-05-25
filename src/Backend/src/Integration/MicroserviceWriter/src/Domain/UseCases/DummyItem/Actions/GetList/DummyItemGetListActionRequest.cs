namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.DummyItem.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="Query">Запрос.</param>
public record DummyItemGetListActionRequest(DummyItemListQuery Query) :
  IQuery<Result<List<DummyItemSingleDTO>>>;
