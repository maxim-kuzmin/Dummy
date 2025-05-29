namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.HttpClient.AppIncomingEvent;

/// <summary>
/// Расширения входящего события приложения.
/// </summary>
public static class AppIncomingEventExtensions
{
  /// <summary>
  /// Преобразовать к содержимому запроса HTTP.
  /// </summary>
  /// <param name="data">Данные.</param>
  /// <returns>Содержимое запроса HTTP.</returns>
  public static JsonContent ToHttpRequestContent(this AppIncomingEventCommandDataSection data)
  {
    return JsonContent.Create(data);
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this AppIncomingEventSingleQuery query)
  {
    return $"{AppIncomingEventSettings.Root}/{query.ObjectId}";
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this AppIncomingEventListQuery query)
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

    return $"{AppIncomingEventSettings.Root}{queryString}";
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this AppIncomingEventPageQuery query)
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

    return $"{AppIncomingEventSettings.Root}/page/{pageNumber}{queryString}";
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this AppIncomingEventDeleteCommand command)
  {
    return $"{AppIncomingEventSettings.Root}/{command.ObjectId}";
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this AppIncomingEventSaveCommand command)
  {
    return command.IsUpdate ? $"{AppIncomingEventSettings.Root}/{command.ObjectId}" : AppIncomingEventSettings.Root;
  }
}
