namespace Makc.Dummy.Writer.DomainModel.AppOutgoingEventPayload.Entity;

/// <summary>
/// Настройки сущности полезной нагрузки исходящего события приложения.
/// </summary>
public record AppOutgoingEventPayloadEntitySettings
{
  /// <summary>
  /// Максимальная длина для данных.
  /// </summary>
  public int MaxLengthForData { get; protected set; }
}
