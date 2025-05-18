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
  public static DummyItemGetListActionQuery ToDummyItemGetListActionQuery(this DummyItemGetListEndpointRequest request)
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
  public static DummyItemSaveActionCommand ToDummyItemSaveActionCommand(
    this DummyItemCreateEndpointRequest request)
  {
    return new(false, 0, request.Name);
  }

  /// <summary>
  /// Преобразовать к команде действия по сохранению фиктивного предмета.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Команда.</returns>
  public static DummyItemSaveActionCommand ToDummyItemSaveActionCommand(
    this DummyItemUpdateEndpointRequest request)
  {
    return new(true, request.Id, request.Name);
  }
}
