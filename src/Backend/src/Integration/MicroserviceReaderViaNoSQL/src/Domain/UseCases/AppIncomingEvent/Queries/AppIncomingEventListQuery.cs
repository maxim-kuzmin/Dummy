namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent.Queries;

/// <summary>
/// Запрос списка входящих событий приложения.
/// </summary>
/// <param name="MaxCount">Макимальное количество.</param>
/// <param name="Sort">Сортировка.</param>
/// <param name="Filter">Фильтр.</param>
public record AppIncomingEventListQuery(
  int MaxCount,
  QuerySortSection? Sort,
  AppIncomingEventQueryFilterSection? Filter) :
  AppIncomingEventCountQuery(Filter);
