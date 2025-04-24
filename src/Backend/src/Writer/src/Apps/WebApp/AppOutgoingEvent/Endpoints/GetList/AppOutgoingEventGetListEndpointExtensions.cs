namespace Makc.Dummy.Writer.Apps.WebApp.AppOutgoingEvent.Endpoints.GetList;

/// <summary>
/// Расширения конечной точки получения списка исходящих событий приложения.
/// </summary>
public static class AppOutgoingEventGetListEndpointExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по получению списка исходящих событий приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия по получению списка исходящих событий приложения.</returns>
  public static AppOutgoingEventGetListActionQuery ToAppOutgoingEventGetListActionQuery(this AppOutgoingEventGetListEndpointRequest request)
  {
    AppOutgoingEventPageQuery pageQuery = new()
    {
      Page = new QueryPageSection(request.CurrentPage, request.ItemsPerPage),
      Filter = new AppOutgoingEventQueryFilterSection(request.Query)
    };

    return new(pageQuery)
    {
      Sort = request.SortField.ToAppOutgoingEventQuerySortSection(request.SortIsDesc)
    };
  }
}
