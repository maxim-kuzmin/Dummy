namespace Makc.Dummy.MicroserviceReader.Apps.WebApp.AppIncomingEvent.Endpoints;

/// <summary>
/// Расширения конечных точек входящего события приложения.
/// </summary>
public static class AppIncomingEventEndpointsExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по получению списка входящих событий приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия по получению списка входящих событий приложения.</returns>
  public static AppIncomingEventGetListActionQuery ToAppIncomingEventGetListActionQuery(
    this AppIncomingEventGetListEndpointRequest request)
  {
    AppIncomingEventPageQuery pageQuery = new()
    {
      Page = new(request.CurrentPage, request.ItemsPerPage),
      Filter = new(request.Query)
    };

    return new(pageQuery)
    {
      Sort = request.SortField.ToAppIncomingEventQuerySortSection(request.SortIsDesc)
    };
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда.</returns>
  public static AppIncomingEventSaveActionCommand ToAppIncomingEventSaveActionCommand(
    this AppIncomingEventCreateEndpointRequest request)
  {
    return new(
      false,
      string.Empty,
      request.EventId,
      request.EventName,
      request.LastLoadingAt,
      request.LastLoadingError,
      request.LoadedAt,
      request.PayloadCount,
      request.PayloadTotalCount,
      request.ProcessedAt);
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда.</returns>
  public static AppIncomingEventSaveActionCommand ToAppIncomingEventSaveActionCommand(
    this AppIncomingEventUpdateEndpointRequest request)
  {
    return new(
      true,
      request.ObjectId,
      request.EventId,
      request.EventName,
      request.LastLoadingAt,
      request.LastLoadingError,
      request.LoadedAt,
      request.PayloadCount,
      request.PayloadTotalCount,
      request.ProcessedAt);
  }
}
