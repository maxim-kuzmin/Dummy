namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEventPayload.Queries;

/// <summary>
/// Запрос страницы полезных нагрузок исходящего события приложения.
/// </summary>
/// <param name="Page">Страница.</param>
/// <param name="Sort">Сортировка.</param>
/// <param name="Filter">Фильтр.</param>
public record AppOutgoingEventPayloadPageQuery(
  QueryPageSection? Page,
  QuerySortSection? Sort,
  AppOutgoingEventPayloadQueryFilterSection? Filter) :
  AppOutgoingEventPayloadListQuery(Sort, Filter);
