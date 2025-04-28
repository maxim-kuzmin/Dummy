namespace Makc.Dummy.Writer.DomainModel.AppOutgoingEventPayload.Entity;

/// <summary>
/// Настройки сущности полезной нагрузки исходящего события приложения.
/// </summary>
public record AppOutgoingEventPayloadEntitySettings
{
  /// <summary>
  /// Максимальная длина для токена параллелизма.
  /// </summary>
  public int MaxLengthForConcurrencyToken { get; protected set; }

  /// <summary>
  /// Максимальная длина для данных.
  /// </summary>
  public int MaxLengthForData { get; protected set; }

  /// <summary>
  /// Максимальная длина для идентификатора сущности.
  /// </summary>
  public int MaxLengthForEntityId { get; protected set; }

  /// <summary>
  /// Максимальная длина для имени сущности.
  /// </summary>
  public int MaxLengthForEntityName { get; protected set; }
}
