namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.HttpClient.AppOutgoingEventPayload;

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

    IEnumerable<KeyValuePair<string, string?>> parameters = [
      new("MaxCount", query.MaxCount.ToString()),
      new("SortField", (sort?.Field ?? string.Empty)),
      new("SortIsDesc", (sort?.IsDesc ?? false).ToString()),
      new("Query", filter?.FullTextSearchQuery ?? string.Empty),
      new("EventId", filter?.AppOutgoingEventId.ToString()),
    ];

    var queryString = QueryString.Create(parameters);

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

    IEnumerable<KeyValuePair<string, string?>> parameters = [
      new("ItemsPerPage", (page?.Size ?? 0).ToString()),
      new("SortField", (sort?.Field ?? string.Empty)),
      new("SortIsDesc", (sort?.IsDesc ?? false).ToString()),
      new("Query", filter?.FullTextSearchQuery ?? string.Empty),
      new("EventId", filter?.AppOutgoingEventId.ToString()),
    ];

    var queryString = QueryString.Create(parameters);

    return $"{AppOutgoingEventPayloadSettings.Root}/page/{page?.Number ?? 1}{queryString}";
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
