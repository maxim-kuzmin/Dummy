namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.DummyItem.Queries;

/// <summary>
/// Запрос единственного фиктивного предмета.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
/// <param name="Id">Идентификатор.</param>
public record DummyItemSingleQuery(string? ObjectId, long Id);
