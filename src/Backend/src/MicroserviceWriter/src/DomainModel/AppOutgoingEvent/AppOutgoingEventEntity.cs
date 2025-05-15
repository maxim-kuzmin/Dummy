namespace Makc.Dummy.MicroserviceWriter.DomainModel.AppOutgoingEvent;

/// <summary>
/// Сущность исходящего события приложения.
/// </summary>
public class AppOutgoingEventEntity : EntityBaseWithStructPrimaryKey<long>, IAggregateRoot
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
  /// Имя.
  /// </summary>
  public string Name { get; set; } = string.Empty;

  /// <summary>
  /// Дата публикации.
  /// </summary>
  public DateTimeOffset? PublishedAt { get; set; }

  /// <summary>
  /// Полезные нагрузки.
  /// </summary>
  public IEnumerable<AppOutgoingEventPayloadEntity>? Payloads { get; }

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
