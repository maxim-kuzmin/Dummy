namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.Model.AppOutgoingEvent.Entity;

/// <summary>
/// Настройки сущности исходящего события приложения.
/// </summary>
public record AppOutgoingEventEntitySettings
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
