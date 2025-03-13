namespace Makc.Dummy.Writer.DomainUseCases.DummyItem;

/// <summary>
/// Настройки фиктивного предмета.
/// </summary>
public class DummyItemSettings
{
  /// <summary>
  /// Раздел порядка сортировки по умолчанию в запросе.
  /// </summary>
  public static readonly QueryOrderSection DefaultQueryOrderSection = new(nameof(DummyItemEntity.Id), true);
}
