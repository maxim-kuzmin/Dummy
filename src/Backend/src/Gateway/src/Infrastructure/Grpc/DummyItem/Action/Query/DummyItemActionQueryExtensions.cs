namespace Makc.Dummy.Gateway.Infrastructure.Grpc.DummyItem.Action.Query;

/// <summary>
/// Расширения запросов действия с фиктивным предметом.
/// </summary>
public static class DummyItemActionQueryExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия на получение фиктивного предмета.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Запрос действия на получение фиктивного предмета.</returns>
  public static DummyItemGetActionRequest ToDummyItemGetActionRequest(this DummyItemGetActionQuery query)
  {
    return new DummyItemGetActionRequest
    {
      Id = query.Id,
    };
  }

  /// <summary>
  /// Преобразовать к запросу действия на получение списка фиктивных предметов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>Запрос действия на получение списка фиктивных предметов.</returns>
  public static DummyItemGetListActionRequest ToDummyItemGetListActionRequest(
    this DummyItemGetListActionQuery query)
  {
    return new()
    {
      Page = new ActionRequestPage()
      {
        Number = query.Page.Number,
        Size = query.Page.Size,
      },
      Filter = new DummyItemGetListActionRequestFilter()
      {
        FullTextSearchQuery = query.Filter.FullTextSearchQuery
      }
    };
  }
}
