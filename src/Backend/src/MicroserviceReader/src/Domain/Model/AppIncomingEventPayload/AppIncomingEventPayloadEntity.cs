namespace Makc.Dummy.MicroserviceReader.Domain.Model.AppIncomingEventPayload;

/// <summary>
/// Сущность полезной нагрузки входящего события приложения.
/// </summary>
public class AppIncomingEventPayloadEntity : EntityBaseWithStringPrimaryKey, IAggregateRoot
{
  /// <summary>
  /// Идентификатор объекта входящего события приложения.
  /// </summary>
  public string AppIncomingEventObjectId { get; set; } = string.Empty;

  /// <summary>
  /// Токен параллелизма.
  /// </summary>
  public string ConcurrencyToken { get; set; } = string.Empty;

  /// <summary>
  /// Дата создания.
  /// </summary>
  public DateTimeOffset CreatedAt { get; set; }

  /// <summary>
  /// Данные.
  /// </summary>
  public string? Data { get; set; }

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
  /// Идентификатор полезной нагрузки события.
  /// </summary>
  public string EventPayloadId { get; set; } = string.Empty;

  /// <summary>
  /// Идентификатор объекта.
  /// </summary>
  public string? ObjectId { get; set; }

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
  public sealed override string? GetPrimaryKey()
  {
    return ObjectId;
  }
}
