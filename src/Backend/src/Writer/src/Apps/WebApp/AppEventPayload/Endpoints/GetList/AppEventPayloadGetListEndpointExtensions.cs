namespace Makc.Dummy.Writer.Apps.WebApp.AppEventPayload.Endpoints.GetList;

/// <summary>
/// Расширения конечной точки получения списка полезных нагрузок события приложения.
/// </summary>
public static class AppEventPayloadGetListEndpointExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по получению списка полезных нагрузок события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия по получению списка полезных нагрузок события приложения.</returns>
  public static AppEventPayloadGetListActionQuery ToAppEventPayloadGetListActionQuery(
    this AppEventPayloadGetListEndpointRequest request)
  {
    AppEventPayloadCountQuery countQuery = new()
    {
      Page = new QueryPageSection(request.CurrentPage, request.ItemsPerPage),
      Filter = new AppEventPayloadQueryFilterSection(request.Query)
    };

    return new(countQuery)
    {
      Order = new QueryOrderSection(nameof(AppEventPayloadEntity.Id), false)
    };
  }
}
