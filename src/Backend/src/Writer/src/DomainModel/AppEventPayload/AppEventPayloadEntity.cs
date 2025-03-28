﻿namespace Makc.Dummy.Writer.DomainModel.AppEventPayload;

/// <summary>
/// Сущность полезной нагрузки события приложения.
/// </summary>
public class AppEventPayloadEntity : EntityBaseWithStructPrimaryKey<long>, IAggregateRoot
{
  /// <summary>
  /// Идентификатор события приложения.
  /// </summary>
  public long AppEventId { get; set; }

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
  public AppEventEntity? Event { get; private set; }

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
