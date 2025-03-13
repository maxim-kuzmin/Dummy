namespace Makc.Dummy.Writer.Apps.WebApp.DummyItem.Endpoints.GetList;

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
      Page = new QueryPageSection(request.CurrentPage, request.ItemsPerPage),
      Filter = new DummyItemQueryFilterSection(request.Query)
    };

    return new(pageQuery)
    {
      Order = new QueryOrderSection(nameof(DummyItemEntity.Id), false)
    };
  }
}
