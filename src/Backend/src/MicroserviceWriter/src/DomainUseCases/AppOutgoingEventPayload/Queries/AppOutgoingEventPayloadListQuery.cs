namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEventPayload.Queries;

/// <summary>
/// Запрос списка полезных нагрузок исходящего события приложения.
/// </summary>
/// <param name="Sort">Сортировка.</param>
/// <param name="Filter">Фильтр.</param>
public record AppOutgoingEventPayloadListQuery(
  QuerySortSection? Sort,
  AppOutgoingEventPayloadQueryFilterSection? Filter) :
  AppOutgoingEventPayloadCountQuery(Filter);
