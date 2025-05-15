namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEvent.Queries;

/// <summary>
/// Запрос списка входящих событий приложения.
/// </summary>
/// <param name="PageQuery">Запрос страницы.</param>
public record AppIncomingEventListQuery(AppIncomingEventPageQuery PageQuery) : ListQuery
{
}
