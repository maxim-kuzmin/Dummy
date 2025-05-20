namespace Makc.Dummy.Gateway.Domain.UseCasesForMicroserviceReader.DummyItem.Queries;

/// <summary>
/// Запрос единственного фиктивного предмета.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record DummyItemSingleQuery(string ObjectId);
