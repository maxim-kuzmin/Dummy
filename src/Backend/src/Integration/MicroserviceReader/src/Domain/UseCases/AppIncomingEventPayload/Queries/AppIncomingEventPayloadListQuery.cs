namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCases.AppIncomingEventPayload.Queries;

/// <summary>
/// Запрос списка полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="MaxCount">Макимальное количество.</param>
/// <param name="Sort">Сортировка.</param>
/// <param name="Filter">Фильтр.</param>
public record AppIncomingEventPayloadListQuery(
  int MaxCount,
  QuerySortSection? Sort,
  AppIncomingEventPayloadQueryFilterSection? Filter) :
  AppIncomingEventPayloadCountQuery(Filter);
