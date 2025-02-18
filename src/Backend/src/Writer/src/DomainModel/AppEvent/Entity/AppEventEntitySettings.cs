namespace Makc.Dummy.Writer.DomainModel.AppEvent.Entity;

/// <summary>
/// Настройки сущности события приложения.
/// </summary>
public record AppEventEntitySettings
{
  /// <summary>
  /// Максимальная длина для имени.
  /// </summary>
  public int MaxLengthForName { get; protected set; }
}
