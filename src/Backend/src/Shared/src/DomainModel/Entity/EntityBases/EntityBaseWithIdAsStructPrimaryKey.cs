namespace Makc.Dummy.Shared.DomainModel.Entity.EntityBases;

/// <summary>
/// Основа сущности с идентификатором в качестве структурного первичного ключа.
/// </summary>
/// <typeparam name="TPrimaryKey">Тип первичного ключа.</typeparam>
public abstract class EntityBaseWithIdAsStructPrimaryKey<TPrimaryKey> : EntityBase<TPrimaryKey>
  where TPrimaryKey : struct, IEquatable<TPrimaryKey>
{
  /// <summary>
  /// Идентификатор.
  /// </summary>
  public TPrimaryKey Id { get; set; }

  /// <inheritdoc/>
  public sealed override TPrimaryKey GetDefaultPrimaryKey()
  {
    return default;
  }

  /// <inheritdoc/>
  public sealed override TPrimaryKey GetPrimaryKey()
  {
    return Id;
  }
}
