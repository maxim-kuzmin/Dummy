namespace Makc.Dummy.Writer.DomainUseCases.AppEvent.Queries;

/// <summary>
/// Запрос списка событий приложения.
/// </summary>
/// <param name="PageQuery">Запрос страницы.</param>
public record AppEventListQuery(AppEventPageQuery PageQuery) : ListQuery
{
}
