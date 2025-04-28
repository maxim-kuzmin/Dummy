namespace Makc.Dummy.Writer.DomainModel.DummyItem.Entity;

/// <summary>
/// Настройки сущности фиктивного предмета.
/// </summary>
public record DummyItemEntitySettings
{
  /// <summary>
  /// Максимальная длина для токена параллелизма.
  /// </summary>
  public int MaxLengthForConcurrencyToken { get; protected set; }

  /// <summary>
  /// Максимальная длина для имени.
  /// </summary>
  public int MaxLengthForName { get; protected set; }
}
