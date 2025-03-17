namespace Makc.Dummy.Gateway.Infrastructure.HttpForWriter.DummyItem;

/// <summary>
/// Расширения фиктивного предмета.
/// </summary>
public static class DummyItemExtensions
{
  /// <summary>
  /// Преобразовать к содержимому запроса HTTP.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Содержимое запроса HTTP.</returns>
  public static JsonContent ToHttpRequestContent(this DummyItemCreateActionCommand command)
  {
    return JsonContent.Create(command);
  }

  /// <summary>
  /// Преобразовать к содержимому запроса HTTP.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Содержимое запроса HTTP.</returns>
  public static JsonContent ToHttpRequestContent(this DummyItemUpdateActionCommand command)
  {
    return JsonContent.Create(command);
  }

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
      new("SortField", query.Sort.Field),
      new("SortIsDesc", query.Sort.IsDesc.ToString()),
      new("Query", query.Filter.FullTextSearchQuery)
    ];

    var queryString = QueryString.Create(parameters);

    return $"{DummyItemSettings.Root}{queryString}";
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this DummyItemDeleteActionCommand command)
  {
    return $"{DummyItemSettings.Root}/{command.Id}";
  }

  /// <summary>
  /// Преобразовать к URL запроса HTTP.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>URL запроса HTTP.</returns>
  public static string ToHttpRequestUrl(this DummyItemUpdateActionCommand command)
  {
    return $"{DummyItemSettings.Root}/{command.Id}";
  }
}
