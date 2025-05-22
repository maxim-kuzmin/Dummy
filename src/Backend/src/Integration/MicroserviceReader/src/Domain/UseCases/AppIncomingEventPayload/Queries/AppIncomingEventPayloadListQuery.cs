namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCases.AppIncomingEventPayload.Queries;

/// <summary>
/// Запрос списка полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="Sort">Сортировка.</param>
/// <param name="Filter">Фильтр.</param>
public record AppIncomingEventPayloadListQuery(
  QuerySortSection? Sort,
  AppIncomingEventPayloadQueryFilterSection? Filter) :
  AppIncomingEventPayloadCountQuery(Filter);
