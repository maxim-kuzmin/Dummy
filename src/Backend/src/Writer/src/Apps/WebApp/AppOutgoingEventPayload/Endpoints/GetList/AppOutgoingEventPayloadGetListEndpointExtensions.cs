namespace Makc.Dummy.Writer.Apps.WebApp.AppOutgoingEventPayload.Endpoints.GetList;

/// <summary>
/// Расширения конечной точки получения списка полезных нагрузок исходящего события приложения.
/// </summary>
public static class AppOutgoingEventPayloadGetListEndpointExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по получению списка полезных нагрузок исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия по получению списка полезных нагрузок исходящего события приложения.</returns>
  public static AppOutgoingEventPayloadGetListActionQuery ToAppOutgoingEventPayloadGetListActionQuery(
    this AppOutgoingEventPayloadGetListEndpointRequest request)
  {
    AppOutgoingEventPayloadPageQuery pageQuery = new()
    {
      Page = new QueryPageSection(request.CurrentPage, request.ItemsPerPage),
      Filter = new AppOutgoingEventPayloadQueryFilterSection(request.Query)
    };

    return new(pageQuery)
    {
      Sort = request.SortField.ToAppOutgoingEventPayloadQuerySortSection(request.SortIsDesc)
    };
  }
}
