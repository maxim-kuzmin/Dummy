namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEventPayload.Queries;

/// <summary>
/// Запрос списка полезных нагрузок входящего события приложения.
/// </summary>
/// <param name="PageQuery">Запрос страницы.</param>
public record AppIncomingEventPayloadListQuery(AppIncomingEventPayloadPageQuery PageQuery) : ListQuery
{
}
