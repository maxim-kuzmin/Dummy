namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.AppOutgoingEventPayload.Queries;

/// <summary>
/// Запрос списка полезных нагрузок исходящего события приложения.
/// </summary>
/// <param name="MaxCount">Макимальное количество.</param>
/// <param name="Sort">Сортировка.</param>
/// <param name="Filter">Фильтр.</param>
public record AppOutgoingEventPayloadListQuery(
  int MaxCount,
  QuerySortSection? Sort,
  AppOutgoingEventPayloadQueryFilterSection? Filter) :
  AppOutgoingEventPayloadCountQuery(Filter);
