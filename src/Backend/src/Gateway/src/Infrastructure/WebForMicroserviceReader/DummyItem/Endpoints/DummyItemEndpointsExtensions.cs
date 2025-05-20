namespace Makc.Dummy.Gateway.Infrastructure.WebForMicroserviceReader.DummyItem.Endpoints;

/// <summary>
/// Расширения конечных точек фиктивного предмета.
/// </summary>
public static class DummyItemEndpointsExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по получению фиктивного предмета.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static DummyItemGetActionRequest ToDummyItemGetActionRequest(
    this DummyItemGetEndpointRequest request)
  {
    DummyItemSingleQuery query = new(request.ObjectId);

    return new(query);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению списка фиктивных предметов.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static DummyItemGetListActionRequest ToDummyItemGetListActionRequest(
    this DummyItemGetListEndpointRequest request)
  {
    DummyItemPageQuery query = new(
      Page: new(request.CurrentPage, request.ItemsPerPage),
      Sort: request.SortField.ToDummyItemQuerySortSection(request.SortIsDesc),
      Filter: new(request.Query));

    return new(query);
  }
}
