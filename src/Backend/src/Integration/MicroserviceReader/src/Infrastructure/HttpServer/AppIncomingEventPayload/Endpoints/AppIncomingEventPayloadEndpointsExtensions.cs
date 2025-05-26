namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.HttpServer.AppIncomingEventPayload.Endpoints;

/// <summary>
/// Расширения конечных точек полезной нагрузки входящего события приложения.
/// </summary>
public static class AppIncomingEventPayloadEndpointsExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по удалению полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static AppIncomingEventPayloadDeleteActionRequest ToAppIncomingEventPayloadDeleteActionRequest(
    this AppIncomingEventPayloadDeleteEndpointRequest request)
  {
    AppIncomingEventPayloadDeleteCommand command = new(request.ObjectId);

    return new(command);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static AppIncomingEventPayloadGetActionRequest ToAppIncomingEventPayloadGetActionRequest(
    this AppIncomingEventPayloadGetEndpointRequest request)
  {
    AppIncomingEventPayloadSingleQuery query = new(request.ObjectId);

    return new(query);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению списка полезных нагрузок входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static AppIncomingEventPayloadGetListActionRequest ToAppIncomingEventPayloadGetListActionRequest(
    this AppIncomingEventPayloadGetListEndpointRequest request)
  {
    AppIncomingEventPayloadListQuery query = new(
      MaxCount: request.MaxCount,
      Sort: request.SortField.ToAppIncomingEventPayloadQuerySortSection(request.SortIsDesc),
      Filter: new(request.Query));

    return new(query);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению страницы полезных нагрузок входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static AppIncomingEventPayloadGetPageActionRequest ToAppIncomingEventPayloadGetPageActionRequest(
    this AppIncomingEventPayloadGetPageEndpointRequest request)
  {
    AppIncomingEventPayloadPageQuery query = new(
      Page: new(request.CurrentPage, request.ItemsPerPage),
      Sort: request.SortField.ToAppIncomingEventPayloadQuerySortSection(request.SortIsDesc),
      Filter: new(request.Query));

    return new(query);
  }

  /// <summary>
  /// Преобразовать к запросу действия по сохранению полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static AppIncomingEventPayloadSaveActionCommand ToAppIncomingEventPayloadSaveActionRequest(
    this AppIncomingEventPayloadCreateEndpointRequest request)
  {
    AppIncomingEventPayloadSaveCommand command = new(
      IsUpdate: false,
      ObjectId: string.Empty,
      Data: new(
        AppIncomingEventObjectId: request.AppIncomingEventObjectId,
        EventPayloadId: request.EventPayloadId,
        Payload: request.Payload));

    return new(command);
  }

  /// <summary>
  /// Преобразовать к запросу действия по сохранению полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static AppIncomingEventPayloadSaveActionCommand ToAppIncomingEventPayloadSaveActionRequest(
    this AppIncomingEventPayloadUpdateEndpointRequest request)
  {
    AppIncomingEventPayloadSaveCommand command = new(
      IsUpdate: true,
      ObjectId: request.ObjectId,
      Data: new(
        AppIncomingEventObjectId: request.AppIncomingEventObjectId,
        EventPayloadId: request.EventPayloadId,
        Payload: request.Payload));

    return new(command);
  }
}
