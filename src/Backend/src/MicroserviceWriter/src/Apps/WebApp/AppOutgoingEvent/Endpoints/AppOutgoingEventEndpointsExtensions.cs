namespace Makc.Dummy.MicroserviceWriter.Apps.WebApp.AppOutgoingEvent.Endpoints;

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
  public static AppOutgoingEventGetListActionRequest ToAppOutgoingEventGetListActionRequest(
    this AppOutgoingEventGetListEndpointRequest request)
  {
    AppOutgoingEventPageQuery query = new(
      Page: new QueryPageSection(request.CurrentPage, request.ItemsPerPage),
      Sort: request.SortField.ToAppOutgoingEventQuerySortSection(request.SortIsDesc),
      Filter: new AppOutgoingEventQueryFilterSection(request.Query));

    return new(query);
  }

  /// <summary>
  /// Преобразовать к запросу действия по сохранению исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда.</returns>
  public static AppOutgoingEventSaveActionRequest ToAppOutgoingEventSaveActionRequest(
    this AppOutgoingEventCreateEndpointRequest request)
  {
    AppOutgoingEventSaveCommand command = new(
      IsUpdate: false,
      Id: 0,
      Data: new(Name: request.Name, PublishedAt: request.PublishedAt));

    return new(command);
  }

  /// <summary>
  /// Преобразовать к запросу действия по сохранению исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда.</returns>
  public static AppOutgoingEventSaveActionRequest ToAppOutgoingEventSaveActionRequest(
    this AppOutgoingEventUpdateEndpointRequest request)
  {
    AppOutgoingEventSaveCommand command = new(
      IsUpdate: true,
      Id: request.Id,
      Data: new(Name: request.Name, PublishedAt: request.PublishedAt));

    return new(command);
  }
}
