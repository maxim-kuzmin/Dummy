namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.HttpClient.AppIncomingEventPayload;

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
  public static string ToHttpRequestUrl(this AppIncomingEventPayloadPageQuery query)
  {
    var filter = query.Filter;
    var page = query.Page;
    var sort = query.Sort;

    IEnumerable<KeyValuePair<string, string?>> parameters = [
      new("CurrentPage", (page?.Number ?? 0).ToString()),
      new("ItemsPerPage", (page?.Size ?? 0).ToString()),
      new("SortField", (sort?.Field ?? string.Empty)),
      new("SortIsDesc", (sort?.IsDesc ?? false).ToString()),
      new("Query", filter?.FullTextSearchQuery ?? string.Empty)
    ];

    var queryString = QueryString.Create(parameters);

    return $"{AppIncomingEventPayloadSettings.Root}{queryString}";
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
