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
  /// Максимальная длина для идентификатора события.
  /// </summary>
  public int MaxLengthForEventId { get; protected set; }

  /// <summary>
  /// Максимальная длина для имени события.
  /// </summary>
  public int MaxLengthForEventName { get; protected set; }
}
