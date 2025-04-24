namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEventPayload;

/// <summary>
/// Настройки полезной нагрузки исходящего события приложения.
/// </summary>
public class AppOutgoingEventPayloadSettings
{
  /// <summary>
  /// Поле сортировки для идентификатора исходящего события приложения.
  /// </summary>
  public const string SortFieldForAppOutgoingEventId = "AppOutgoingEventId";

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
  static AppOutgoingEventPayloadSettings()
  {
    DefaultQuerySortSection = new(SortFieldForId, true);
  }
}
