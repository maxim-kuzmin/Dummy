namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload;

/// <summary>
/// Настройки полезной нагрузки события приложения.
/// </summary>
public class AppEventPayloadSettings
{
  /// <summary>
  /// Поле сортировки для идентификатора события приложения.
  /// </summary>
  public const string OrderFieldForAppEventId = "AppEventId";

  /// <summary>
  /// Поле сортировки для данных.
  /// </summary>
  public const string OrderFieldForData = "Data";

  /// <summary>
  /// Поле сортировки для идентификатора.
  /// </summary>
  public const string OrderFieldForId = "Id";

  /// <summary>
  /// Раздел порядка сортировки по умолчанию в запросе.
  /// </summary>
  public static readonly QueryOrderSection DefaultQueryOrderSection;

  /// <summary>
  /// Конструктор.
  /// </summary>
  static AppEventPayloadSettings()
  {
    DefaultQueryOrderSection = new(OrderFieldForId, true);
  }
}
