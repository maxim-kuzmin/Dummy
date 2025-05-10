namespace Makc.Dummy.Writer.Apps.WebApp.AppOutgoingEventPayload.Endpoints;

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
  public static AppOutgoingEventPayloadGetListActionQuery ToAppOutgoingEventPayloadGetListActionQuery(
    this AppOutgoingEventPayloadGetListEndpointRequest request)
  {
    AppOutgoingEventPayloadPageQuery pageQuery = new()
    {
      Page = new QueryPageSection(request.CurrentPage, request.ItemsPerPage),
      Filter = new AppOutgoingEventPayloadQueryFilterSection(request.Query)
    };

    return new(pageQuery)
    {
      Sort = request.SortField.ToAppOutgoingEventPayloadQuerySortSection(request.SortIsDesc)
    };
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда.</returns>
  public static AppOutgoingEventPayloadSaveActionCommand ToAppOutgoingEventPayloadSaveActionCommand(
    this AppOutgoingEventPayloadCreateEndpointRequest request)
  {
    return new(false, 0, request.AppOutgoingEventId, request.Payload);
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда.</returns>
  public static AppOutgoingEventPayloadSaveActionCommand ToAppOutgoingEventPayloadSaveActionCommand(
    this AppOutgoingEventPayloadUpdateEndpointRequest request)
  {
    return new(true, request.Id, request.AppOutgoingEventId, request.Payload);
  }
}
