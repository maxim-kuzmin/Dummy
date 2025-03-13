namespace Makc.Dummy.Writer.DomainUseCases.AppEvent.Queries;

/// <summary>
/// Запрос списка событий приложения.
/// </summary>
/// <param name="CountQuery">Запрос количества.</param>
public record AppEventListQuery(AppEventCountQuery CountQuery) : ListQuery
{
}
