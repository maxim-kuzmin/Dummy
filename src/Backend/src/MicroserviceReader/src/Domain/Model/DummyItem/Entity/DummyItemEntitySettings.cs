namespace Makc.Dummy.MicroserviceReader.Domain.Model.DummyItem.Entity;

/// <summary>
/// Настройки сущности фиктивного предмета.
/// </summary>
public record DummyItemEntitySettings
{
  /// <summary>
  /// Максимальная длина для токена параллелизма.
  /// </summary>
  public int MaxLengthForConcurrencyToken { get; protected set; } = 255;

  /// <summary>
  /// Максимальная длина для имени.
  /// </summary>
  public int MaxLengthForName { get; protected set; } = 255;
}
