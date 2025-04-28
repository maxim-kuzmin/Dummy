namespace Makc.Dummy.Writer.DomainModel.AppOutgoingEvent.Entity;

/// <summary>
/// Настройки сущности исходящего события приложения.
/// </summary>
public record AppOutgoingEventEntitySettings
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
