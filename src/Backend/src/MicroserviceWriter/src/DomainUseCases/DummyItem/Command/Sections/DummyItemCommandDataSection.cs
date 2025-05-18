namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.DummyItem.Command.Sections;

/// <summary>
/// Раздел данных команды фиктивного предмета.
/// </summary>
/// <param name="Name">Имя.</param>
public record DummyItemCommandDataSection(
  string Name);
