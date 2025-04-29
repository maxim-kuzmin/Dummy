namespace Makc.Dummy.Reader.DomainModel.AppIncomingEvent.Entity;

/// <summary>
/// Настройки сущности входящего события приложения.
/// </summary>
public record AppIncomingEventEntitySettings
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
