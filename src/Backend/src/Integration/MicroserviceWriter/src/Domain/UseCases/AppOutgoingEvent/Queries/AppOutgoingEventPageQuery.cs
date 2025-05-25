namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent.Queries;

/// <summary>
/// Запрос страницы исходящих событий приложения.
/// </summary>
/// <param name="Page">Страница.</param>
/// <param name="Sort">Сортировка.</param>
/// <param name="Filter">Фильтр.</param>
public record AppOutgoingEventPageQuery(
  QueryPageSection? Page,
  QuerySortSection? Sort,
  AppOutgoingEventQueryFilterSection? Filter) :
  AppOutgoingEventListQuery(Page?.Size ?? 0, Sort, Filter);
