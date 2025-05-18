namespace Makc.Dummy.MicroserviceWriter.Apps.WebApp.AppOutgoingEventPayload.Endpoints;

/// <summary>
/// Расширения конечных точек полезной нагрузки исходящего события приложения.
/// </summary>
public static class AppOutgoingEventPayloadEndpointsExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по получению списка полезных нагрузок исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия по получению списка полезных нагрузок исходящего события приложения.</returns>
  public static AppOutgoingEventPayloadGetListActionRequest ToAppOutgoingEventPayloadGetListActionRequest(
    this AppOutgoingEventPayloadGetListEndpointRequest request)
  {
    AppOutgoingEventPayloadPageQuery query = new(
      Page: new QueryPageSection(request.CurrentPage, request.ItemsPerPage),
      Sort: request.SortField.ToAppOutgoingEventPayloadQuerySortSection(request.SortIsDesc),
      Filter: new AppOutgoingEventPayloadQueryFilterSection(request.Query));

    return new(query);
  }

  /// <summary>
  /// Преобразовать к запросу действия по сохранению полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда.</returns>
  public static AppOutgoingEventPayloadSaveActionRequest ToAppOutgoingEventPayloadSaveActionRequest(
    this AppOutgoingEventPayloadCreateEndpointRequest request)
  {
    AppOutgoingEventPayloadSaveCommand command = new(
      IsUpdate: false,
      Id: 0,
      Data: new(AppOutgoingEventId: request.AppOutgoingEventId, Payload: request.Payload));

    return new(command);
  }

  /// <summary>
  /// Преобразовать к запросу действия по сохранению полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда.</returns>
  public static AppOutgoingEventPayloadSaveActionRequest ToAppOutgoingEventPayloadSaveActionRequest(
    this AppOutgoingEventPayloadUpdateEndpointRequest request)
  {
    AppOutgoingEventPayloadSaveCommand command = new(
      IsUpdate: true,
      Id: request.Id,
      Data: new(AppOutgoingEventId: request.AppOutgoingEventId, Payload: request.Payload));

    return new(command);
  }
}
