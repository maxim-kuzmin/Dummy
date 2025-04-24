namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.Queries;

/// <summary>
/// Запрос списка исходящих событий приложения.
/// </summary>
/// <param name="PageQuery">Запрос страницы.</param>
public record AppOutgoingEventListQuery(AppOutgoingEventPageQuery PageQuery) : ListQuery
{
}
