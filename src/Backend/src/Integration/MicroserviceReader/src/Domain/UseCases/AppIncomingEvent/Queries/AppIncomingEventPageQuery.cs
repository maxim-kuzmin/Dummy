namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCases.AppIncomingEvent.Queries;

/// <summary>
/// Запрос страницы входящих событий приложения.
/// </summary>
/// <param name="Page">Страница.</param>
/// <param name="Sort">Сортировка.</param>
/// <param name="Filter">Фильтр.</param>
public record AppIncomingEventPageQuery(
  QueryPageSection? Page,
  QuerySortSection? Sort,
  AppIncomingEventQueryFilterSection? Filter) :
  AppIncomingEventListQuery(Sort, Filter);
