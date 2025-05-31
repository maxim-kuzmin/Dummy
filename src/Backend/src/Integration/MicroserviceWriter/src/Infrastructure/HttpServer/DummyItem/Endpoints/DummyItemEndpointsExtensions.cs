namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.HttpServer.DummyItem.Endpoints;

/// <summary>
/// Расширения конечных точек фиктивного предмета.
/// </summary>
public static class DummyItemEndpointsExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по удалению фиктивного предмета.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static DummyItemDeleteActionRequest ToDummyItemDeleteActionRequest(
    this DummyItemDeleteEndpointRequest request)
  {
    DummyItemDeleteCommand command = new(request.Id);

    return new(command);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению фиктивного предмета.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static DummyItemGetActionRequest ToDummyItemGetActionRequest(
    this DummyItemGetEndpointRequest request)
  {
    DummyItemSingleQuery query = new(request.Id);

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
    DummyItemListQuery query = new(
      MaxCount: request.MaxCount,
      Sort: request.SortField.ToDummyItemQuerySortSection(request.SortIsDesc),
      Filter: new(FullTextSearchQuery: request.Query));

    return new(query);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению страницы фиктивных предметов.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static DummyItemGetPageActionRequest ToDummyItemGetPageActionRequest(
    this DummyItemGetPageEndpointRequest request)
  {
    DummyItemPageQuery query = new(
      Page: new(Number: request.CurrentPage, Size: request.ItemsPerPage),
      Sort: request.SortField.ToDummyItemQuerySortSection(request.SortIsDesc),
      Filter: new(FullTextSearchQuery: request.Query));

    return new(query);
  }

  /// <summary>
  /// Преобразовать к запросу действия по сохранению фиктивного предмета.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static DummyItemSaveActionRequest ToDummyItemSaveActionRequest(
    this DummyItemCreateEndpointRequest request)
  {
    DummyItemSaveCommand command = new(
      IsUpdate: false,
      Id: 0,
      Data: new(request.Name));

    return new(command);
  }

  /// <summary>
  /// Преобразовать к запросу действия по сохранению фиктивного предмета.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static DummyItemSaveActionRequest ToDummyItemSaveActionRequest(
    this DummyItemUpdateEndpointRequest request)
  {
    DummyItemSaveCommand command = new(
      IsUpdate: true,
      Id: request.Id,
      Data: new(Name: request.Name));

    return new(command);
  }
}
