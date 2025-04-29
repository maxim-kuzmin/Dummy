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
  /// Когда создано.
  /// </summary>
  public DateTimeOffset CreatedAt { get; set; }

  /// <summary>
  /// Идентификатор.
  /// </summary>
  public long Id { get; set; }

  /// <summary>
  /// Опубликовано ли?
  /// </summary>
  public bool IsPublished { get; set; }

  /// <summary>
  /// Имя.
  /// </summary>
  public string Name { get; set; } = string.Empty;

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
