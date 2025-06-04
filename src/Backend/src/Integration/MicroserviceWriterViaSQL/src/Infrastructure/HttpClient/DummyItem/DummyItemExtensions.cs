namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.HttpClient.DummyItem;

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
    return $"{DummyItemSettings.Root}/{query.Id}";
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

    string? sortField = null;
    string? sortIsDesc = null;

    if (sort != null)
    {
      sortField = sort.Field;
      sortIsDesc = sort.IsDesc.ToString();
    }

    string? maxCount = null;

    if (query.MaxCount > 0)
    {
      maxCount = query.MaxCount.ToString();
    }

    IEnumerable<KeyValuePair<string, string?>> parameters = [
      new("MaxCount", maxCount),
      new("SortField", sortField),
      new("SortIsDesc", sortIsDesc),
      new("Query", filter?.FullTextSearchQuery)
    ];

    var queryString = parameters.ToQueryString();

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

    string? sortField = null;
    string? sortIsDesc = null;

    if (sort != null)
    {
      sortField = sort.Field;
      sortIsDesc = sort.IsDesc.ToString();
    }

    string pageNumber = "1";
    string? itemsPerPage = null;

    if (page != null)
    {
      if (page.Number > 1)
      {
        pageNumber = page.Number.ToString();
      }

      if (page.Size > 0)
      {
        itemsPerPage = page.Size.ToString();
      }
    }

    IEnumerable<KeyValuePair<string, string?>> parameters = [
      new("ItemsPerPage", itemsPerPage),
      new("SortField", sortField),
      new("SortIsDesc", sortIsDesc),
      new("Query", filter?.FullTextSearchQuery)
    ];

    var queryString = parameters.ToQueryString();

    return $"{DummyItemSettings.Root}/page/{pageNumber}{queryString}";
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this DummyItemDeleteCommand command)
  {
    return $"{DummyItemSettings.Root}/{command.Id}";
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this DummyItemSaveCommand command)
  {
    return command.IsUpdate
      ? $"{DummyItemSettings.Root}/{command.Id}"
      : DummyItemSettings.Root;
  }
}
