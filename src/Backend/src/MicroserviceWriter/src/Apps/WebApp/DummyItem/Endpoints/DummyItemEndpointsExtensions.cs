namespace Makc.Dummy.MicroserviceWriter.Apps.WebApp.DummyItem.Endpoints;

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
  public static DummyItemGetListActionRequest ToDummyItemGetListActionQuery(this DummyItemGetListEndpointRequest request)
  {
    DummyItemPageQuery query = new(
      Page: new(request.CurrentPage, request.ItemsPerPage),
      Sort: request.SortField.ToDummyItemQuerySortSection(request.SortIsDesc),
      Filter: new(request.Query));

    return new(query);
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению фиктивного предмета.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда.</returns>
  public static DummyItemSaveActionRequest ToDummyItemSaveActionCommand(
    this DummyItemCreateEndpointRequest request)
  {
    DummyItemSaveCommand command = new(
      IsUpdate: false,
      Id: 0,
      Data: new(request.Name));

    return new(command);
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению фиктивного предмета.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда.</returns>
  public static DummyItemSaveActionRequest ToDummyItemSaveActionCommand(
    this DummyItemUpdateEndpointRequest request)
  {
    DummyItemSaveCommand command = new(
      IsUpdate: true,
      Id: request.Id,
      Data: new(request.Name));

    return new(command);
  }
}
