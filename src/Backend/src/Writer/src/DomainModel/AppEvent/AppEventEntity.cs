﻿namespace Makc.Dummy.Writer.DomainModel.AppEvent;

/// <summary>
/// Сущность события приложения.
/// </summary>
public class AppEventEntity : EntityBaseWithStructPrimaryKey<long>, IAggregateRoot
{
  /// <summary>
  /// Токен конкуренции.
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
  public IEnumerable<AppEventPayloadEntity>? Payloads { get; }

  /// <inheritdoc/>
  public sealed override long GetPrimaryKey()
  {
    return Id;
  }
}
