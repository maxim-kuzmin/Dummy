namespace Makc.Dummy.MicroserviceReader.DomainModel.DummyItem;

/// <summary>
/// Сущность фиктивного предмета.
/// </summary>
public class DummyItemEntity : EntityBaseWithStringPrimaryKey, IAggregateRoot
{
  /// <summary>
  /// Токен параллелизма.
  /// </summary>
  public string ConcurrencyToken { get; set; } = string.Empty;

  /// <summary>
  /// Идентификатор.
  /// </summary>
  public long Id { get; set; }

  /// <summary>
  /// Идентификатор в виде строки.
  /// </summary>
  public string IdAsString { get; set; } = string.Empty;

  /// <summary>
  /// Имя.
  /// </summary>
  public string Name { get; set; } = string.Empty;

  /// <summary>
  /// Идентификатор объекта.
  /// </summary>
  public string? ObjectId { get; set; }

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
