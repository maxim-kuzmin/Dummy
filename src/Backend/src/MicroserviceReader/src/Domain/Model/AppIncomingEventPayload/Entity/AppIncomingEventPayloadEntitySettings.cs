namespace Makc.Dummy.MicroserviceReader.Domain.Model.AppIncomingEventPayload.Entity;

/// <summary>
/// Настройки сущности полезной нагрузки входящего события приложения.
/// </summary>
public record AppIncomingEventPayloadEntitySettings
{
  /// <summary>
  /// Максимальная длина для идентификатора входящего события приложения.
  /// </summary>
  public int MaxLengthForAppIncomingEventId { get; protected set; } = 255;

  /// <summary>
  /// Максимальная длина для токена параллелизма.
  /// </summary>
  public int MaxLengthForConcurrencyToken { get; protected set; } = 255;

  /// <summary>
  /// Максимальная длина для данных.
  /// </summary>
  public int MaxLengthForData { get; protected set; } = 0;

  /// <summary>
  /// Максимальная длина для идентификатора сущности.
  /// </summary>
  public int MaxLengthForEntityId { get; protected set; } = 255;

  /// <summary>
  /// Максимальная длина для имени сущности.
  /// </summary>
  public int MaxLengthForEntityName { get; protected set; } = 255;

  /// <summary>
  /// Максимальная длина для идентификатора полезной нагрузки события.
  /// </summary>
  public int MaxLengthForEventPayloadId { get; protected set; } = 255;
}
