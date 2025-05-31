namespace Makc.Dummy.MicroserviceReader.Domain.Model.AppIncomingEvent.Entity;

/// <summary>
/// Настройки сущности входящего события приложения.
/// </summary>
public record AppIncomingEventEntitySettings
{
  /// <summary>
  /// Максимальная длина для токена параллелизма.
  /// </summary>
  public int MaxLengthForConcurrencyToken { get; protected set; } = 255;

  /// <summary>
  /// Максимальная длина для идентификатора события.
  /// </summary>
  public int MaxLengthForEventId { get; protected set; } = 255;

  /// <summary>
  /// Максимальная длина для имени события.
  /// </summary>
  public int MaxLengthForEventName { get; protected set; } = 255;

  /// <summary>
  /// Максимальная длина для последней ошибки загрузки.
  /// </summary>
  public int MaxLengthForLastLoadingError { get; protected set; } = 0;

  /// <summary>
  /// Максимальная длина для последней ошибки обработки.
  /// </summary>
  public int MaxLengthForLastProcessingError { get; protected set; } = 0;
}
