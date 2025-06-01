namespace Makc.Dummy.Shared.Core.App.Event;

/// <summary>
/// Расширения события приложения.
/// </summary>
public static class AppEventExtensions
{
  /// <summary>
  /// Преобразовать к данным полезной нагрузки события приложения в виде словаря.
  /// </summary>
  /// <param name="payload">Полезная нагрузка.</param>
  /// <returns>Полезная нагрузка события приложения с данными виде словаря.</returns>
  public static Dictionary<string, string?>? ToAppEventPayloadDataAsDictionary(this string? data)
  {
    return data != null ? JsonSerializer.Deserialize<Dictionary<string, string?>>(data) : null;
  }

  /// <summary>
  /// Преобразовать к полезной нагрузке события приложения с данными в виде словаря.
  /// </summary>
  /// <param name="payload">Полезная нагрузка.</param>
  /// <returns>Полезная нагрузка события приложения с данными в виде словаря.</returns>
  public static AppEventPayloadWithDataAsDictionary ToAppEventPayloadWithDataAsDictionary(
    this AppEventPayloadWithDataAsString payload)
  {
    var data = payload.Data.ToAppEventPayloadDataAsDictionary();

    AppEventPayloadWithDataAsDictionary result = new(data);

    Copy(payload, result);

    return result;
  }

  /// <summary>
  /// Преобразовать к полезной нагрузке события приложения с данными в виде строки.
  /// </summary>
  /// <param name="payload">Полезная нагрузка.</param>
  /// <param name="position">Позиция.</param>
  /// <returns>Полезная нагрузка события приложения с данными в виде строки.</returns>
  public static AppEventPayloadWithDataAsString ToAppEventPayloadWithDataAsString(
    this AppEventPayloadWithDataAsDictionary payload,
    int position = 0)
  {
    var result = new AppEventPayloadWithDataAsString(
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
