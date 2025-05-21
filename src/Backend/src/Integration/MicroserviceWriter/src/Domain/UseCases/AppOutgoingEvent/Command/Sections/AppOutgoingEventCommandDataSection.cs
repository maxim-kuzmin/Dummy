namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent.Command.Sections;

/// <summary>
/// Раздел данных команды исходящего события приложения.
/// </summary>
/// <param name="Name">Имя.</param>
/// <param name="PublishedAt">Дата публикации.</param>
public record AppOutgoingEventCommandDataSection(
  string Name,
  DateTimeOffset? PublishedAt);
