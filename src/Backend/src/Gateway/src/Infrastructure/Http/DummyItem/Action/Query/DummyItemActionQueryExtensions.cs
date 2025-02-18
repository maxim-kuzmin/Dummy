namespace Makc.Dummy.Gateway.Infrastructure.Http.DummyItem.Action.Query;

/// <summary>
/// Расширения запросов действия с фиктивным предметом для HTTP.
/// </summary>
public static class DummyItemActionQueryExtensions
{
  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this DummyItemGetActionQuery query)
  {
    return $"{DummyItemSettings.Root}/{query.Id}";
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this DummyItemGetListActionQuery query)
  {
    IEnumerable<KeyValuePair<string, string?>> parameters = [
      new("CurrentPage", query.Page.Number.ToString()),
      new("ItemsPerPage", query.Page.Size.ToString()),
      new("Query", query.Filter.FullTextSearchQuery)
    ];

    var queryString = QueryString.Create(parameters);

    return $"{DummyItemSettings.Root}{queryString}";
  }
}
