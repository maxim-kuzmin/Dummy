namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.HttpClient.DummyItem;

/// <summary>
/// Расширения фиктивного предмета.
/// </summary>
public static class DummyItemExtensions
{
  /// <summary>
  /// Преобразовать к содержимому запроса HTTP.
  /// </summary>
  /// <param name="data">Данные.</param>
  /// <returns>Содержимое запроса HTTP.</returns>
  public static JsonContent ToHttpRequestContent(this DummyItemCommandDataSection data)
  {
    return JsonContent.Create(data);
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this DummyItemSingleQuery query)
  {
    return $"{DummyItemSettings.Root}/{query.ObjectId}";
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this DummyItemListQuery query)
  {
    var sort = query.Sort;
    var filter = query.Filter;

    IEnumerable<KeyValuePair<string, string?>> parameters = [
      new("MaxCount", query.MaxCount.ToString()),
      new("SortField", (sort?.Field ?? string.Empty)),
      new("SortIsDesc", (sort?.IsDesc ?? false).ToString()),
      new("Query", filter?.FullTextSearchQuery ?? string.Empty)
    ];

    var queryString = QueryString.Create(parameters);

    return $"{DummyItemSettings.Root}{queryString}";
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this DummyItemPageQuery query)
  {
    var page = query.Page;
    var sort = query.Sort;
    var filter = query.Filter;

    IEnumerable<KeyValuePair<string, string?>> parameters = [
      new("ItemsPerPage", (page?.Size ?? 0).ToString()),
      new("SortField", (sort?.Field ?? string.Empty)),
      new("SortIsDesc", (sort?.IsDesc ?? false).ToString()),
      new("Query", filter?.FullTextSearchQuery ?? string.Empty)
    ];

    var queryString = QueryString.Create(parameters);

    return $"{DummyItemSettings.Root}/page/{page?.Number ?? 1}{queryString}";
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this DummyItemDeleteCommand command)
  {
    return $"{DummyItemSettings.Root}/{command.ObjectId}";
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this DummyItemSaveCommand command)
  {
    return command.IsUpdate ? $"{DummyItemSettings.Root}/{command.ObjectId}" : DummyItemSettings.Root;
  }
}
