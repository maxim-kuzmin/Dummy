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

    IEnumerable<KeyValuePair<string, string?>> parameters = [
      new("MaxCount", query.MaxCount.ToString()),
      new("SortField", (sort?.Field ?? string.Empty)),
      new("SortIsDesc", (sort?.IsDesc ?? false).ToString()),
      new("Query", filter?.FullTextSearchQuery ?? string.Empty)
    ];

    var queryString = QueryString.Create(parameters);

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

    IEnumerable<KeyValuePair<string, string?>> parameters = [
      new("ItemsPerPage", (page?.Size ?? 0).ToString()),
      new("SortField", (sort?.Field ?? string.Empty)),
      new("SortIsDesc", (sort?.IsDesc ?? false).ToString()),
      new("Query", filter?.FullTextSearchQuery ?? string.Empty)
    ];

    var queryString = QueryString.Create(parameters);

    return $"{AppIncomingEventSettings.Root}/page/{page?.Number ?? 1}{queryString}";
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
