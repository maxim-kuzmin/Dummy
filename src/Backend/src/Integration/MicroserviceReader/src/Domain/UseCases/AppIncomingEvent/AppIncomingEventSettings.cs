namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCases.AppIncomingEvent;

/// <summary>
/// Настройки входящего события приложения.
/// </summary>
public class AppIncomingEventSettings
{
  /// <summary>
  /// Поле сортировки для идентификатора.
  /// </summary>
  public const string SortFieldForId = "Id";

  /// <summary>
  /// Поле сортировки для имени.
  /// </summary>
  public const string SortFieldForName = "Name";

  /// <summary>
  /// Раздел сортировки по умолчанию в запросе.
  /// </summary>
  public static readonly QuerySortSection DefaultQuerySortSection;

  /// <summary>
  /// Конструктор.
  /// </summary>
  static AppIncomingEventSettings()
  {
    DefaultQuerySortSection = new(SortFieldForId, true);
  }
}
