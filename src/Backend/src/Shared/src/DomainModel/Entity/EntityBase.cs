namespace Makc.Dummy.Shared.DomainModel.Entity;

/// <summary>
/// Основа сущности.
/// </summary>
/// <typeparam name="TPrimaryKey">Тип первичного ключа.</typeparam>
public abstract class EntityBase<TPrimaryKey> : IEntityBase<TPrimaryKey>
  where TPrimaryKey : IEquatable<TPrimaryKey>
{
  /// <inheritdoc/>
  public virtual object DeepCopy()
  {
    return MemberwiseClone();
  }

  /// <inheritdoc/>
  public abstract TPrimaryKey GetDefaultPrimaryKey();

  /// <inheritdoc/>
  public abstract TPrimaryKey GetPrimaryKeyOrDefault();
}
