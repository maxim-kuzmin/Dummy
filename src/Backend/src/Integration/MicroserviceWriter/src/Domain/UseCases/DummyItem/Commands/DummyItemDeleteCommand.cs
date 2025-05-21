namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.DummyItem.Commands;

/// <summary>
/// Команда удаления фиктивного предмета.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record DummyItemDeleteCommand(long Id);
