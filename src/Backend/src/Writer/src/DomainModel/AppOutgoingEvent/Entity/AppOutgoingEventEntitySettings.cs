namespace Makc.Dummy.Writer.DomainModel.AppOutgoingEvent.Entity;

/// <summary>
/// Настройки сущности исходящего события приложения.
/// </summary>
public record AppOutgoingEventEntitySettings
{
  /// <summary>
  /// Максимальная длина для имени.
  /// </summary>
  public int MaxLengthForName { get; protected set; }
}
