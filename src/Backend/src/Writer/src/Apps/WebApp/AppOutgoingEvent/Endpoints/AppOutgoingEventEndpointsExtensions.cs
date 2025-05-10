namespace Makc.Dummy.Writer.Apps.WebApp.AppOutgoingEvent.Endpoints;

/// <summary>
/// Расширения конечных точек исходящего события приложения.
/// </summary>
public static class AppOutgoingEventEndpointsExtensions
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

  /// <summary>
  /// Преобразовать к команде действия по сохранению исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда.</returns>
  public static AppOutgoingEventSaveActionCommand ToAppOutgoingEventSaveActionCommand(
    this AppOutgoingEventCreateEndpointRequest request)
  {
    return new(false, 0, request.Name, request.PublishedAt);
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда.</returns>
  public static AppOutgoingEventSaveActionCommand ToAppOutgoingEventSaveActionCommand(
    this AppOutgoingEventUpdateEndpointRequest request)
  {
    return new(true, request.Id, request.Name, request.PublishedAt);
  }
}
