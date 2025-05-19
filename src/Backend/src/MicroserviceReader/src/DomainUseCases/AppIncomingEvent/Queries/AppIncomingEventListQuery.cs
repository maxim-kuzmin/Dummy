namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEvent.Queries;

/// <summary>
/// Запрос списка входящих событий приложения.
/// </summary>
/// <param name="Sort">Сортировка.</param>
/// <param name="Filter">Фильтр.</param>
public record AppIncomingEventListQuery(
  QuerySortSection? Sort,
  AppIncomingEventQueryFilterSection? Filter) :
  AppIncomingEventCountQuery(Filter);
