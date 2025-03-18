namespace Makc.Dummy.Reader.DomainModel.DummyItem;

/// <summary>
/// Сущность фиктивного предмета.
/// </summary>
public class DummyItemEntity : EntityBaseWithStringPrimaryKey, IAggregateRoot
{
  /// <summary>
  /// Токен конкуренции.
  /// </summary>
  public Guid ConcurrencyToken { get; set; }

  /// <summary>
  /// Идентификатор.
  /// </summary>
  public long Id { get; set; }

  /// <summary>
  /// Имя.
  /// </summary>
  public string Name { get; set; } = string.Empty;

  /// <summary>
  /// Идентификатор объекта.
  /// </summary>
  public string? ObjectId { get; set; }

  /// <inheritdoc/>
  public sealed override string? GetPrimaryKey()
  {
    return ObjectId;
  }
}
