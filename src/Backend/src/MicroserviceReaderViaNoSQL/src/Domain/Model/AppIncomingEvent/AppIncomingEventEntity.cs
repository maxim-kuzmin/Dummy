namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.Model.AppIncomingEvent;

/// <summary>
/// Сущность входящего события приложения.
/// </summary>
public class AppIncomingEventEntity : EntityBaseWithStringPrimaryKey, IAggregateRoot
{
  /// <summary>
  /// Токен параллелизма.
  /// </summary>
  public string ConcurrencyToken { get; set; } = string.Empty;

  /// <summary>
  /// Дата создания.
  /// </summary>
  public DateTimeOffset CreatedAt { get; set; }

  /// <summary>
  /// Идентификатор события.
  /// </summary>
  public string EventId { get; set; } = string.Empty;

  /// <summary>
  /// Имя события.
  /// </summary>
  public string EventName { get; set; } = string.Empty;

  /// <summary>
  /// Последняя дата загрузки.
  /// </summary>
  public DateTimeOffset? LastLoadingAt { get; set; }

  /// <summary>
  /// Последняя ошибка загрузки.
  /// </summary>
  public string? LastLoadingError { get; set; }

  /// <summary>
  /// Последняя дата обработки.
  /// </summary>
  public DateTimeOffset? LastProcessingAt { get; set; }

  /// <summary>
  /// Последняя ошибка обработки.
  /// </summary>
  public string? LastProcessingError { get; set; }

  /// <summary>
  /// Дата загрузки.
  /// </summary>
  public DateTimeOffset? LoadedAt { get; set; }

  /// <summary>
  /// Идентификатор объекта.
  /// </summary>
  public string? ObjectId { get; set; }

  /// <summary>
  /// Количество полезной нагрузки.
  /// </summary>
  public long PayloadCount { get; set; }

  /// <summary>
  /// Общее количество полезной нагрузки.
  /// </summary>
  public long PayloadTotalCount { get; set; }

  /// <summary>
  /// Дата обработки.
  /// </summary>
  public DateTimeOffset? ProcessedAt { get; set; }

  /// <inheritdoc/>
  public sealed override string GetConcurrencyToken()
  {
    return ConcurrencyToken;
  }

  /// <inheritdoc/>
  public sealed override string? GetPrimaryKey()
  {
    return ObjectId;
  }
}
