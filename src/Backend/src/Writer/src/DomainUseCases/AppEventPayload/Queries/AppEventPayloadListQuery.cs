namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Queries;

/// <summary>
/// Запрос списка полезных нагрузок события приложения.
/// </summary>
/// <param name="PageQuery">Запрос страницы.</param>
public record AppEventPayloadListQuery(AppEventPayloadPageQuery PageQuery) : ListQuery
{
}
