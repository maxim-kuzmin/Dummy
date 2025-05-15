namespace Makc.Dummy.MicroserviceReader.Apps.WebApp.AppIncomingEventPayload.Endpoints;

/// <summary>
/// Расширения конечных точек полезной нагрузки входящего события приложения.
/// </summary>
public static class AppIncomingEventPayloadEndpointsExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по получению списка полезных нагрузок входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия по получению списка полезных нагрузок входящего события приложения.</returns>
  public static AppIncomingEventPayloadGetListActionQuery ToAppIncomingEventPayloadGetListActionQuery(
    this AppIncomingEventPayloadGetListEndpointRequest request)
  {
    AppIncomingEventPayloadPageQuery pageQuery = new()
    {
      Page = new(request.CurrentPage, request.ItemsPerPage),
      Filter = new(request.Query)
    };

    return new(pageQuery)
    {
      Sort = request.SortField.ToAppIncomingEventPayloadQuerySortSection(request.SortIsDesc)
    };
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда.</returns>
  public static AppIncomingEventPayloadSaveActionCommand ToAppIncomingEventPayloadSaveActionCommand(
    this AppIncomingEventPayloadCreateEndpointRequest request)
  {
    return new(
      false,
      string.Empty,
      request.AppIncomingEventObjectId,
      request.Payload);
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда.</returns>
  public static AppIncomingEventPayloadSaveActionCommand ToAppIncomingEventPayloadSaveActionCommand(
    this AppIncomingEventPayloadUpdateEndpointRequest request)
  {
    return new(
      true,
      request.ObjectId,
      request.AppIncomingEventObjectId,
      request.Payload);
  }
}
