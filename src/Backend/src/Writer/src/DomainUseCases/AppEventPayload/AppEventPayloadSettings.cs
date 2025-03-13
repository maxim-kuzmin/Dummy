namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload;

/// <summary>
/// Настройки полезной нагрузки события приложения.
/// </summary>
public class AppEventPayloadSettings
{
  /// <summary>
  /// Поле сортировки для идентификатора события приложения.
  /// </summary>
  public const string SortFieldForAppEventId = "AppEventId";

  /// <summary>
  /// Поле сортировки для данных.
  /// </summary>
  public const string SortFieldForData = "Data";

  /// <summary>
  /// Поле сортировки для идентификатора.
  /// </summary>
  public const string SortFieldForId = "Id";

  /// <summary>
  /// Раздел сортировки по умолчанию в запросе.
  /// </summary>
  public static readonly QuerySortSection DefaultQuerySortSection;

  /// <summary>
  /// Конструктор.
  /// </summary>
  static AppEventPayloadSettings()
  {
    DefaultQuerySortSection = new(SortFieldForId, true);
  }
}
