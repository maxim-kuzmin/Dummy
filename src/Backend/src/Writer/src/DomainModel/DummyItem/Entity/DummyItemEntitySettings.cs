namespace Makc.Dummy.Writer.DomainModel.DummyItem.Entity;

/// <summary>
/// Настройки сущности фиктивного предмета.
/// </summary>
public record DummyItemEntitySettings
{
  /// <summary>
  /// Максимальная длина для имени.
  /// </summary>
  public int MaxLengthForName { get; protected set; }
}
