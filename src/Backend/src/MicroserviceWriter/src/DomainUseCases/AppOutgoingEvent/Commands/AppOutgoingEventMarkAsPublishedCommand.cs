namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEvent.Commands;

/// <summary>
/// Команда пометки исходящих событий приложения как опубликованные.
/// </summary>
public record AppOutgoingEventMarkAsPublishedCommand(
  IEnumerable<long> Ids,
  DateTimeOffset PublishedAt) : AppOutgoingEventUpdatePropertyByIdsCommand<DateTimeOffset>(Ids, PublishedAt)
{
}
