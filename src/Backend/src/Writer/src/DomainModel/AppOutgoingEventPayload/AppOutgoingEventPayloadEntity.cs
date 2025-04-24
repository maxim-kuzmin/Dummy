namespace Makc.Dummy.Writer.DomainModel.AppOutgoingEventPayload;

/// <summary>
/// Сущность полезной нагрузки исходящего события приложения.
/// </summary>
public class AppOutgoingEventPayloadEntity : EntityBaseWithStructPrimaryKey<long>, IAggregateRoot
{
  /// <summary>
  /// Идентификатор исходящего события приложения.
  /// </summary>
  public long AppOutgoingEventId { get; set; }

  /// <summary>
  /// Токен конкуренции.
  /// </summary>
  public Guid ConcurrencyToken { get; set; }

  /// <summary>
  /// Данные.
  /// </summary>
  public string Data { get; set; } = string.Empty;

  /// <summary>
  /// Событие.
  /// </summary>
  public AppOutgoingEventEntity? Event { get; private set; }

  /// <summary>
  /// Идентификатор.
  /// </summary>
  public long Id { get; set; }

  /// <inheritdoc/>
  public sealed override long GetPrimaryKey()
  {
    return Id;
  }
}
