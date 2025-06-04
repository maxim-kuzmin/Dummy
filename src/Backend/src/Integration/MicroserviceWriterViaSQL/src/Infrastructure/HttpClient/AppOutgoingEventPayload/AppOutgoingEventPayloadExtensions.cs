namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.HttpClient.AppOutgoingEventPayload;

/// <summary>
/// Расширения полезной нагрузки исходящего события приложения.
/// </summary>
public static class AppOutgoingEventPayloadExtensions
{
  /// <summary>
  /// Преобразовать к содержимому запроса HTTP.
  /// </summary>
  /// <param name="data">Данные.</param>
  /// <returns>Содержимое запроса HTTP.</returns>
  public static JsonContent ToHttpRequestContent(this AppOutgoingEventPayloadCommandDataSection data)
  {
    return JsonContent.Create(data);
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this AppOutgoingEventPayloadSingleQuery query)
  {
    return $"{AppOutgoingEventPayloadSettings.Root}/{query.Id}";
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this AppOutgoingEventPayloadListQuery query)
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

    return $"{AppOutgoingEventPayloadSettings.Root}{queryString}";
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this AppOutgoingEventPayloadPageQuery query)
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

    return $"{AppOutgoingEventPayloadSettings.Root}/page/{pageNumber}{queryString}";
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this AppOutgoingEventPayloadDeleteCommand command)
  {
    return $"{AppOutgoingEventPayloadSettings.Root}/{command.Id}";
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this AppOutgoingEventPayloadSaveCommand command)
  {
    return command.IsUpdate
      ? $"{AppOutgoingEventPayloadSettings.Root}/{command.Id}"
      : AppOutgoingEventPayloadSettings.Root;
  }
}
