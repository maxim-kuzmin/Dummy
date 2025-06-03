namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCases.AppIncomingEvent;

/// <summary>
/// Настройки входящего события приложения.
/// </summary>
public class AppIncomingEventSettings
{
  /// <summary>
  /// Поле сортировки для идентификатора объекта.
  /// </summary>
  public const string SortFieldForObjectId = "ObjectId";

  /// <summary>
  /// Поле сортировки для идентификатора события.
  /// </summary>
  public const string SortFieldForEventId = "EventId";

  /// <summary>
  /// Поле сортировки для имени события.
  /// </summary>
  public const string SortFieldForEventName = "EventName";

  /// <summary>
  /// Раздел сортировки по умолчанию в запросе.
  /// </summary>
  public static readonly QuerySortSection DefaultQuerySortSection;

  /// <summary>
  /// Конструктор.
  /// </summary>
  static AppIncomingEventSettings()
  {
    DefaultQuerySortSection = new(Field: SortFieldForObjectId, IsDesc: true);
  }
}
