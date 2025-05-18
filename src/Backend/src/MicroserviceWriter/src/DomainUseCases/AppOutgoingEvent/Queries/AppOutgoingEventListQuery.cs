namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEvent.Queries;

/// <summary>
/// Запрос списка исходящих событий приложения.
/// </summary>
/// <param name="Sort">Сортировка.</param>
/// <param name="Filter">Фильтр.</param>
public record AppOutgoingEventListQuery(
  QuerySortSection? Sort,
  AppOutgoingEventQueryFilterSection? Filter) :
  AppOutgoingEventCountQuery(Filter);
