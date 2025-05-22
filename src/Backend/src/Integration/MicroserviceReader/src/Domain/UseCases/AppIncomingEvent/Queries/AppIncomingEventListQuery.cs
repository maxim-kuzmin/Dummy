namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCases.AppIncomingEvent.Queries;

/// <summary>
/// Запрос списка входящих событий приложения.
/// </summary>
/// <param name="Sort">Сортировка.</param>
/// <param name="Filter">Фильтр.</param>
public record AppIncomingEventListQuery(
  QuerySortSection? Sort,
  AppIncomingEventQueryFilterSection? Filter) :
  AppIncomingEventCountQuery(Filter);
