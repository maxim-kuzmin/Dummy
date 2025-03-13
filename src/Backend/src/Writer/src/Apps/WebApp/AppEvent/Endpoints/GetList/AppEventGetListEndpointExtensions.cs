namespace Makc.Dummy.Writer.Apps.WebApp.AppEvent.Endpoints.GetList;

/// <summary>
/// Расширения конечной точки получения списка событий приложения.
/// </summary>
public static class AppEventGetListEndpointExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по получению списка событий приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия по получению списка событий приложения.</returns>
  public static AppEventGetListActionQuery ToAppEventGetListActionQuery(this AppEventGetListEndpointRequest request)
  {
    return new(
      new QueryPageSection(request.CurrentPage, request.ItemsPerPage),
      new AppEventQueryFilterSection(request.Query));
  }
}
