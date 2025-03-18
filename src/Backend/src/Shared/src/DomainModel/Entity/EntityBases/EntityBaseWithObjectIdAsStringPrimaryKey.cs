namespace Makc.Dummy.Shared.DomainModel.Entity.EntityBases;

/// <summary>
/// Основа сущности с идентификатором объекта в качестве строкового первичного ключа.
/// </summary>
public abstract class EntityBaseWithObjectIdAsStringPrimaryKey : EntityBase<string>  
{
  /// <inheritdoc/>
  public sealed override string GetDefaultPrimaryKey()
  {
    return string.Empty;
  }

  /// <summary>
  /// Получить идентификатор объекта.
  /// </summary>
  /// <returns>Идентификатор объекта.</returns>
  public abstract string? GetObjectId();

  /// <inheritdoc/>
  public sealed override string GetPrimaryKey()
  {
    return GetObjectId() ?? GetDefaultPrimaryKey();
  }
}
