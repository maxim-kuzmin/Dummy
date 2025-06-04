namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpClient.AppIncomingEventPayload;

/// <summary>
/// Расширения полезной нагрузки входящего события приложения.
/// </summary>
public static class AppIncomingEventPayloadExtensions
{
  /// <summary>
  /// Преобразовать к содержимому запроса HTTP.
  /// </summary>
  /// <param name="data">Данные.</param>
  /// <returns>Содержимое запроса HTTP.</returns>
  public static JsonContent ToHttpRequestContent(this AppIncomingEventPayloadCommandDataSection data)
  {
    return JsonContent.Create(data);
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this AppIncomingEventPayloadSingleQuery query)
  {
    return $"{AppIncomingEventPayloadSettings.Root}/{query.ObjectId}";
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this AppIncomingEventPayloadListQuery query)
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

    return $"{AppIncomingEventPayloadSettings.Root}{queryString}";
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this AppIncomingEventPayloadPageQuery query)
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

    return $"{AppIncomingEventPayloadSettings.Root}/page/{pageNumber}{queryString}";
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this AppIncomingEventPayloadDeleteCommand command)
  {
    return $"{AppIncomingEventPayloadSettings.Root}/{command.ObjectId}";
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this AppIncomingEventPayloadSaveCommand command)
  {
    return command.IsUpdate ? $"{AppIncomingEventPayloadSettings.Root}/{command.ObjectId}" : AppIncomingEventPayloadSettings.Root;
  }
}
