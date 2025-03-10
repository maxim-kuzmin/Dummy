namespace Makc.Dummy.Shared.DomainModel.Entity.EntityBases;

/// <summary>
/// Основа сущности с идентификатором объекта в качестве строкового первичного ключа.
/// </summary>
public abstract class EntityBaseWithObjectIdAsStringPrimaryKey : EntityBase<string>  
{
  /// <summary>
  /// Идентификатор.
  /// </summary>
  public string? ObjectId { get; set; }

  /// <inheritdoc/>
  public sealed override string GetDefaultPrimaryKey()
  {
    return string.Empty;
  }

  /// <inheritdoc/>
  public sealed override string GetPrimaryKey()
  {
    return ObjectId ?? GetDefaultPrimaryKey();
  }
}
