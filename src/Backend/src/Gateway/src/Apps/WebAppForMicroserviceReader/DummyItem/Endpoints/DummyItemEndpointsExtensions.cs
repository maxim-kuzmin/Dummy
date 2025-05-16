namespace Makc.Dummy.Gateway.Apps.WebAppForMicroserviceReader.DummyItem.Endpoints;

/// <summary>
/// Расширения конечных точек фиктивного предмета.
/// </summary>
public static class DummyItemEndpointsExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по получению списка фиктивных предметов.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия по получению списка фиктивных предметов.</returns>
  public static DummyItemGetListActionQuery ToDummyItemGetListActionQuery(
    this DummyItemGetListEndpointRequest request)
  {
    return new(new()
    {
      Page = new(request.CurrentPage, request.ItemsPerPage),
      Filter = new(request.Query)
    })
    {
      Sort = request.SortField.ToDummyItemQuerySortSection(request.SortIsDesc)
    };
  }
}
