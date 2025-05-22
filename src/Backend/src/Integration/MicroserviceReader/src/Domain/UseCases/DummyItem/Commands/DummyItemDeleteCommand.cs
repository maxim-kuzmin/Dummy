namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCases.DummyItem.Commands;

/// <summary>
/// Команда удаления фиктивного предмета.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record DummyItemDeleteCommand(string ObjectId);
