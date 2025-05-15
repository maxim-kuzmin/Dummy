namespace Makc.Dummy.MicroserviceReader.DomainUseCases.DummyItem;

/// <summary>
/// Настройки фиктивного предмета.
/// </summary>
public class DummyItemSettings
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
  static DummyItemSettings()
  {
    DefaultQuerySortSection = new(SortFieldForId, true);
  }
}
