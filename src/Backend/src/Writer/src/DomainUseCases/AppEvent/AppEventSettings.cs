namespace Makc.Dummy.Writer.DomainUseCases.AppEvent;

/// <summary>
/// Настройки события приложения.
/// </summary>
public class AppEventSettings
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
  static AppEventSettings()
  {
    DefaultQuerySortSection = new(SortFieldForId, true);
  }
}
