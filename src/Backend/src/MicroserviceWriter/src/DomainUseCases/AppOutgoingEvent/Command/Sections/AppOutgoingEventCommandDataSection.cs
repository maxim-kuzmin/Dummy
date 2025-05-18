namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEvent.Command.Sections;

/// <summary>
/// Раздел данных команды фиктивного предмета.
/// </summary>
/// <param name="Name">Имя.</param>
/// <param name="PublishedAt">Дата публикации.</param>
public record AppOutgoingEventCommandDataSection(
  string Name,
  DateTimeOffset? PublishedAt);
