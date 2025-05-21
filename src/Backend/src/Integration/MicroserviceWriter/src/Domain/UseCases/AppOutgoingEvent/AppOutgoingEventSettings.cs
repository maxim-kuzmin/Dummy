namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent;

/// <summary>
/// Настройки исходящего события приложения.
/// </summary>
public class AppOutgoingEventSettings
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
  static AppOutgoingEventSettings()
  {
    DefaultQuerySortSection = new(Field: SortFieldForId, IsDesc: true);
  }
}
