namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEvent.Commands;

/// <summary>
/// Команда удаления опубликованного.
/// </summary>
/// <param name="MaxDate">Максимальная дата.</param>
public record AppOutgoingEventDeletePublishedCommand(DateTimeOffset? MaxDate);
