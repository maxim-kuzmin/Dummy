namespace Makc.Dummy.Reader.DomainModel.AppIncomingEventPayload;

/// <summary>
/// Сущность полезной нагрузки входящего события приложения.
/// </summary>
public class AppIncomingEventPayloadEntity : EntityBaseWithStructPrimaryKey<long>, IAggregateRoot
{
  /// <summary>
  /// Исходящее событие приложения.
  /// </summary>
  public AppIncomingEventEntity? AppIncomingEvent { get; private set; }

  /// <summary>
  /// Идентификатор входящего события приложения.
  /// </summary>
  public long AppIncomingEventId { get; set; }

  /// <summary>
  /// Токен параллелизма.
  /// </summary>
  public string ConcurrencyToken { get; set; } = string.Empty;

  /// <summary>
  /// Данные.
  /// </summary>
  public string? Data { get; set; }

  /// <summary>
  /// Идентификатор.
  /// </summary>
  public long Id { get; set; }

  /// <summary>
  /// Токен параллелизма для удаления.
  /// </summary>
  public string? EntityConcurrencyTokenToDelete { get; set; }

  /// <summary>
  /// Токен параллелизма для вставки.
  /// </summary>
  public string? EntityConcurrencyTokenToInsert { get; set; }

  /// <summary>
  /// Идентификатор сущности.
  /// </summary>
  public string EntityId { get; set; } = string.Empty;

  /// <summary>
  /// Имя сущности.
  /// </summary>
  public string EntityName { get; set; } = string.Empty;

  /// <summary>
  /// Позиция.
  /// </summary>
  public int Position { get; set; }

  /// <inheritdoc/>
  public sealed override long GetPrimaryKey()
  {
    return Id;
  }
}
