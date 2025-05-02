namespace Makc.Dummy.Shared.Core.App.Event;

/// <summary>
/// Расширения события приложения.
/// </summary>
public static class AppEventExtensions
{
  /// <summary>
  /// Преобразовать к полезной нагрузке события приложения с данными виде словаря.
  /// </summary>
  /// <param name="payload">Полезная нагрузка.</param>
  /// <returns>Полезная нагрузка события приложения с данными виде словаря.</returns>
  public static AppEventPayloadWithDataAsDictionary ToAppEventPayloadWithDataAsDictionary(
    this AppEventPayloadWithDataAsString payload)
  {
    var result = new AppEventPayloadWithDataAsDictionary(
      payload.Data == null ? null : JsonSerializer.Deserialize<Dictionary<string, string?>>(payload.Data));

    Copy(payload, result);

    return result;
  }

  /// <summary>
  /// Преобразовать к полезной нагрузке события приложения с данными виде строки.
  /// </summary>
  /// <param name="payload">Полезная нагрузка.</param>
  /// <returns>Полезная нагрузка события приложения с данными виде строки.</returns>
  public static AppEventPayloadWithDataAsString ToAppEventPayloadWithDataAsString(
    this AppEventPayloadWithDataAsDictionary payload)
  {
    var result = new AppEventPayloadWithDataAsString(
      payload.Data == null ? null : JsonSerializer.Serialize(payload.Data));

    Copy(payload, result);

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
