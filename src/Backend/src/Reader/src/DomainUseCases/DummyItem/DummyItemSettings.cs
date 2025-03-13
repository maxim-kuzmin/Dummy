namespace Makc.Dummy.Reader.DomainUseCases.DummyItem;

/// <summary>
/// Настройки фиктивного предмета.
/// </summary>
public class DummyItemSettings
{
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
  static DummyItemSettings()
  {
    DefaultQueryOrderSection = new(OrderFieldForId, true);
  }
}
