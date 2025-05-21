namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.HttpClient.AppOutgoingEvent;

/// <summary>
/// Расширения исходящего события приложения.
/// </summary>
public static class AppOutgoingEventExtensions
{
  /// <summary>
  /// Преобразовать к содержимому запроса HTTP.
  /// </summary>
  /// <param name="data">Данные.</param>
  /// <returns>Содержимое запроса HTTP.</returns>
  public static JsonContent ToHttpRequestContent(this AppOutgoingEventCommandDataSection data)
  {
    return JsonContent.Create(data);
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this AppOutgoingEventSingleQuery query)
  {
    return $"{AppOutgoingEventSettings.Root}/{query.Id}";
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this AppOutgoingEventPageQuery query)
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

    return $"{AppOutgoingEventSettings.Root}{queryString}";
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this AppOutgoingEventDeleteCommand command)
  {
    return $"{AppOutgoingEventSettings.Root}/{command.Id}";
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this AppOutgoingEventSaveCommand command)
  {
    return command.IsUpdate
      ? $"{AppOutgoingEventSettings.Root}/{command.Id}"
      : AppOutgoingEventSettings.Root;
  }
}
