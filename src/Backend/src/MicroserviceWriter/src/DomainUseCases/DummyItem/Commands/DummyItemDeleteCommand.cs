namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.DummyItem.Commands;

/// <summary>
/// Команда удаления фиктивного предмета.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record DummyItemDeleteCommand(long Id);
