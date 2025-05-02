namespace Makc.Dummy.Writer.DomainModel.AppOutgoingEventPayload;

/// <summary>
/// Сущность полезной нагрузки исходящего события приложения.
/// </summary>
public class AppOutgoingEventPayloadEntity : EntityBaseWithStructPrimaryKey<long>, IAggregateRoot
{
  /// <summary>
  /// Исходящее событие приложения.
  /// </summary>
  public AppOutgoingEventEntity? AppOutgoingEvent { get; private set; }

  /// <summary>
  /// Идентификатор исходящего события приложения.
  /// </summary>
  public long AppOutgoingEventId { get; set; }

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
  public sealed override string GetConcurrencyToken()
  {
    return ConcurrencyToken;
  }

  /// <inheritdoc/>
  public sealed override long GetPrimaryKey()
  {
    return Id;
  }
}
