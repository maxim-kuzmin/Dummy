namespace Makc.Dummy.Gateway.Apps.WebApp.DummyItem.EndpointsForMicroserviceWriter;

/// <summary>
/// Расширения конечных точек фиктивного предмета.
/// </summary>
public static class DummyItemEndpointsExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по получению списка фиктивных предметов для микросекрвиса "Писатель".
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия по получению списка фиктивных предметов для микросекрвиса "Писатель".</returns>
  public static DummyItemGetListActionQueryForMicroserviceWriter ToDummyItemGetListActionQueryForMicroserviceWriter(
    this DummyItemGetListEndpointRequestForMicroserviceWriter request)
  {
    return new(new()
    {
      Page = new(request.CurrentPage, request.ItemsPerPage),
      Filter = new(request.Query)
    })
    {
      Sort = request.SortField.ToDummyItemQuerySortSectionForMicroserviceWriter(request.SortIsDesc)
    };
  }
}
