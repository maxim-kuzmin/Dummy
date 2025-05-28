namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.HttpServer.AppOutgoingEventPayload.Endpoints;

/// <summary>
/// Расширения конечных точек полезной нагрузки исходящего события приложения.
/// </summary>
public static class AppOutgoingEventPayloadEndpointsExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по удалению полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static AppOutgoingEventPayloadDeleteActionRequest ToAppOutgoingEventPayloadDeleteActionRequest(
    this AppOutgoingEventPayloadDeleteEndpointRequest request)
  {
    AppOutgoingEventPayloadDeleteCommand command = new(request.Id);

    return new(command);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static AppOutgoingEventPayloadGetActionRequest ToAppOutgoingEventPayloadGetActionRequest(
    this AppOutgoingEventPayloadGetEndpointRequest request)
  {
    AppOutgoingEventPayloadSingleQuery query = new(request.Id);

    return new(query);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению списка полезных нагрузок исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static AppOutgoingEventPayloadGetListActionRequest ToAppOutgoingEventPayloadGetListActionRequest(
    this AppOutgoingEventPayloadGetListEndpointRequest request)
  {
    AppOutgoingEventPayloadListQuery query = new(
      MaxCount: request.MaxCount,
      Sort: request.SortField.ToAppOutgoingEventPayloadQuerySortSection(request.SortIsDesc),
      Filter: new(FullTextSearchQuery: request.Query, AppOutgoingEventId: request.EventId));

    return new(query);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению страницы полезных нагрузок исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static AppOutgoingEventPayloadGetPageActionRequest ToAppOutgoingEventPayloadGetPageActionRequest(
    this AppOutgoingEventPayloadGetPageEndpointRequest request)
  {
    AppOutgoingEventPayloadPageQuery query = new(
      Page: new(request.CurrentPage, request.ItemsPerPage),
      Sort: request.SortField.ToAppOutgoingEventPayloadQuerySortSection(request.SortIsDesc),
      Filter: new(FullTextSearchQuery: request.Query, AppOutgoingEventId: request.EventId));

    return new(query);
  }

  /// <summary>
  /// Преобразовать к запросу действия по сохранению полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
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
  /// <returns>Запрос действия.</returns>
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
