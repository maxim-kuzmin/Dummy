namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEventPayload.Queries;

/// <summary>
/// Запрос количества полезных нагрузок исходящего события приложения.
/// </summary>
/// <param name="Filter">Фильтр.</param>
public record AppOutgoingEventPayloadCountQuery(
  AppOutgoingEventPayloadQueryFilterSection? Filter);
