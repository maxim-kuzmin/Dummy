namespace Makc.Dummy.Gateway.Domain.UseCasesForMicroserviceReader.DummyItem.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="Query">Запрос.</param>
public record DummyItemGetListActionRequest(DummyItemPageQuery Query) : IQuery<Result<DummyItemPageDTO>>;
