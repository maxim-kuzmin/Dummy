namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.HttpServer.AppIncomingEvent.Endpoints;

/// <summary>
/// Расширения конечных точек входящего события приложения.
/// </summary>
public static class AppIncomingEventEndpointsExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по удалению входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static AppIncomingEventDeleteActionRequest ToAppIncomingEventDeleteActionRequest(
    this AppIncomingEventDeleteEndpointRequest request)
  {
    AppIncomingEventDeleteCommand command = new(request.ObjectId);

    return new(command);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static AppIncomingEventGetActionRequest ToAppIncomingEventGetActionRequest(
    this AppIncomingEventGetEndpointRequest request)
  {
    AppIncomingEventSingleQuery query = new(request.ObjectId);

    return new(query);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению списка входящих событий приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static AppIncomingEventGetListActionRequest ToAppIncomingEventGetListActionRequest(
    this AppIncomingEventGetListEndpointRequest request)
  {
    AppIncomingEventListQuery query = new(
      MaxCount: request.MaxCount,
      Sort: request.SortField.ToAppIncomingEventQuerySortSection(request.SortIsDesc),
      Filter: new(FullTextSearchQuery: request.Query));

    return new(query);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению страницы входящих событий приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static AppIncomingEventGetPageActionRequest ToAppIncomingEventGetPageActionRequest(
    this AppIncomingEventGetPageEndpointRequest request)
  {
    AppIncomingEventPageQuery query = new(
      Page: new(Number: request.CurrentPage, Size: request.ItemsPerPage),
      Sort: request.SortField.ToAppIncomingEventQuerySortSection(request.SortIsDesc),
      Filter: new(FullTextSearchQuery: request.Query));

    return new(query);
  }


  /// <summary>
  /// Преобразовать к команде действия по сохранению входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда.</returns>
  public static AppIncomingEventSaveActionRequest ToAppIncomingEventSaveActionRequest(
    this AppIncomingEventCreateEndpointRequest request)
  {
    AppIncomingEventSaveCommand command = new(
      IsUpdate: false,
      ObjectId: string.Empty,
      Data: new(
        EventId: request.EventId,
        EventName: request.EventName,
        LastLoadingAt: request.LastLoadingAt,
        LastLoadingError: request.LastLoadingError,
        LastProcessingAt: request.LastProcessingAt,
        LastProcessingError: request.LastProcessingError,
        LoadedAt: request.LoadedAt,
        PayloadCount: request.PayloadCount,
        PayloadTotalCount: request.PayloadTotalCount,
        ProcessedAt: request.ProcessedAt));

    return new(command);
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда.</returns>
  public static AppIncomingEventSaveActionRequest ToAppIncomingEventSaveActionRequest(
    this AppIncomingEventUpdateEndpointRequest request)
  {
    AppIncomingEventSaveCommand command = new(
      IsUpdate: true,
      ObjectId: request.ObjectId,
      Data: new(
        EventId: request.EventId,
        EventName: request.EventName,
        LastLoadingAt: request.LastLoadingAt,
        LastLoadingError: request.LastLoadingError,
        LastProcessingAt: request.LastProcessingAt,
        LastProcessingError: request.LastProcessingError,
        LoadedAt: request.LoadedAt,
        PayloadCount: request.PayloadCount,
        PayloadTotalCount: request.PayloadTotalCount,
        ProcessedAt: request.ProcessedAt));

    return new(command);
  }
}
