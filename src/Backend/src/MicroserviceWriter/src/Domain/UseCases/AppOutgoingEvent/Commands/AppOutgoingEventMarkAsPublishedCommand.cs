namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent.Commands;

/// <summary>
/// Команда пометки исходящих событий приложения как опубликованные.
/// </summary>
/// <param name="Ids">Идентификаторы.</param>
/// <param name="PublishedAt">Дата публикации.</param>
public record AppOutgoingEventMarkAsPublishedCommand(IEnumerable<long> Ids, DateTimeOffset PublishedAt);
