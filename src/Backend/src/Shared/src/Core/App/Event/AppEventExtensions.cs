namespace Makc.Dummy.Shared.Core.App.Event;

/// <summary>
/// Расширения события приложения.
/// </summary>
public static class AppEventExtensions
{
  /// <summary>
  /// Преобразовать к данным словарной полезной нагрузки события приложения.
  /// </summary>
  /// <param name="payload">Полезная нагрузка.</param>
  /// <returns>Данные словарной полезной нагрузки события приложения.</returns>
  public static Dictionary<string, string?>? ToToAppEventDictionaryPayloadData(this string? data)
  {
    return data != null ? JsonSerializer.Deserialize<Dictionary<string, string?>>(data) : null;
  }

  /// <summary>
  /// Преобразовать к словарной полезной нагрузке события приложения .
  /// </summary>
  /// <param name="payload">Полезная нагрузка.</param>
  /// <returns>Словарная полезная нагрузка события приложения.</returns>
  public static AppEventDictionaryPayload ToAppEventDictionaryPayload(
    this AppEventStringPayload payload)
  {
    var data = payload.Data.ToToAppEventDictionaryPayloadData();

    AppEventDictionaryPayload result = new(data);

    Copy(payload, result);

    return result;
  }

  /// <summary>
  /// Преобразовать к строковой полезной нагрузке события приложения.
  /// </summary>
  /// <param name="payload">Полезная нагрузка.</param>
  /// <param name="position">Позиция.</param>
  /// <returns>Строковая полезная нагрузка события приложения.</returns>
  public static AppEventStringPayload ToAppEventStringPayload(
    this AppEventDictionaryPayload payload,
    int position = 0)
  {
    var result = new AppEventStringPayload(
      payload.Data.Count > 0 ? JsonSerializer.Serialize(payload.Data) : null);

    Copy(payload, result);

    if (position > 0)
    {
      result.Position = position;
    }

    return result;
  }

  private static void Copy(AppEventPayload source, AppEventPayload target)
  {    
    target.EntityConcurrencyTokenToDelete = source.EntityConcurrencyTokenToDelete;
    target.EntityConcurrencyTokenToInsert = source.EntityConcurrencyTokenToInsert;
    target.EntityId = source.EntityId;
    target.EntityName = source.EntityName;
    target.Position = source.Position;
  }
}
