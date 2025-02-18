namespace Makc.Dummy.Writer.DomainModel.AppEventPayload.Entity;

/// <summary>
/// Настройки сущности полезной нагрузки события приложения.
/// </summary>
public record AppEventPayloadEntitySettings
{
  /// <summary>
  /// Максимальная длина для данных.
  /// </summary>
  public int MaxLengthForData { get; protected set; }
}
