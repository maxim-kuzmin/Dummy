namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEventPayload.Queries;

/// <summary>
/// Запрос страницы полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="Page">Страница.</param>
/// <param name="Sort">Сортировка.</param>
/// <param name="Filter">Фильтр.</param>
public record AppIncomingEventPayloadPageQuery(
  QueryPageSection? Page,
  QuerySortSection? Sort,
  AppIncomingEventPayloadQueryFilterSection? Filter) :
  AppIncomingEventPayloadListQuery(Page?.Size ?? 0, Sort, Filter);
