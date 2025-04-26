namespace Makc.Dummy.Writer.DomainModel.AppOutgoingEvent;

/// <summary>
/// Сущность исходящего события приложения.
/// </summary>
public class AppOutgoingEventEntity : EntityBaseWithStructPrimaryKey<long>, IAggregateRoot
{
  /// <summary>
  /// Токен параллелизма.
  /// </summary>
  public Guid ConcurrencyToken { get; set; }

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
  public IEnumerable<AppOutgoingEventPayloadEntity>? Payloads { get; }

  /// <inheritdoc/>
  public sealed override long GetPrimaryKey()
  {
    return Id;
  }
}
