namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Queries;

/// <summary>
/// Запрос списка полезных нагрузок события приложения.
/// </summary>
/// <param name="CountQuery">Запрос количества.</param>
public record AppEventPayloadListQuery(AppEventPayloadCountQuery CountQuery) : ListQuery
{
}
