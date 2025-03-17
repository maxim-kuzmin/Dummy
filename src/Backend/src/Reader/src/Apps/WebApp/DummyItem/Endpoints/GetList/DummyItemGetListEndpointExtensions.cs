namespace Makc.Dummy.Reader.Apps.WebApp.DummyItem.Endpoints.GetList;

/// <summary>
/// Расширения конечной точки получения списка фиктивных предметов.
/// </summary>
public static class DummyItemGetListEndpointExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по получению списка фиктивных предметов.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия по получению списка фиктивных предметов.</returns>
  public static DummyItemGetListActionQuery ToDummyItemGetListActionQuery(this DummyItemGetListEndpointRequest request)
  {
    DummyItemPageQuery pageQuery = new()
    {
      Page = new(request.CurrentPage, request.ItemsPerPage),
      Filter = new(request.Query)
    };

    return new(pageQuery)
    {
      Sort = request.SortField.ToDummyItemQuerySortSection(request.SortIsDesc)
    };
  }
}
