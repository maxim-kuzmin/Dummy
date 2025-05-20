namespace Makc.Dummy.Gateway.Domain.UseCasesForMicroserviceReader.DummyItem.Commands;

/// <summary>
/// Команда удаления фиктивного предмета.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record DummyItemDeleteCommand(string ObjectId);
