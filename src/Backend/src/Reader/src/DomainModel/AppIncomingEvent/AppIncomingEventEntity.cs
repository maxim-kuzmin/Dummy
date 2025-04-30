namespace Makc.Dummy.Reader.DomainModel.AppIncomingEvent;

/// <summary>
/// Сущность входящего события приложения.
/// </summary>
public class AppIncomingEventEntity : EntityBaseWithStructPrimaryKey<long>, IAggregateRoot
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
  /// Идентификатор.
  /// </summary>
  public long Id { get; set; }

  /// <summary>
  /// Дата загрузки.
  /// </summary>
  public DateTimeOffset? LoadedAt { get; set; }

  /// <summary>
  /// Имя.
  /// </summary>
  public string Name { get; set; } = string.Empty;

  /// <summary>
  /// Дата обработки.
  /// </summary>
  public DateTimeOffset? ProcessedAt { get; set; }

  /// <summary>
  /// Полезные нагрузки.
  /// </summary>
  public IEnumerable<AppIncomingEventPayloadEntity>? Payloads { get; }

  /// <inheritdoc/>
  public sealed override long GetPrimaryKey()
  {
    return Id;
  }
}
