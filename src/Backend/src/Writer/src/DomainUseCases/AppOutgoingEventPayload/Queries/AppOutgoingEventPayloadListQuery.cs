namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEventPayload.Queries;

/// <summary>
/// Запрос списка полезных нагрузок исходящего события приложения.
/// </summary>
/// <param name="PageQuery">Запрос страницы.</param>
public record AppOutgoingEventPayloadListQuery(AppOutgoingEventPayloadPageQuery PageQuery) : ListQuery
{
}
