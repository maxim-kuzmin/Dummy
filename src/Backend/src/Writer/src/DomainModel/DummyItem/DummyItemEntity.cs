namespace Makc.Dummy.Writer.DomainModel.DummyItem;

/// <summary>
/// Сущность фиктивного предмета.
/// </summary>
public class DummyItemEntity : EntityBaseWithStructPrimaryKey<long>, IAggregateRoot
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

  /// <inheritdoc/>
  public sealed override long GetPrimaryKey()
  {
    return Id;
  }
}
