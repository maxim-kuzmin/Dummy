namespace Makc.Dummy.Shared.DomainModel.Entity.EntityBases;

/// <summary>
/// Основа сущности с первичным ключом в виде строки.
/// </summary>
public abstract class EntityBaseWithStringPrimaryKey : EntityBase<string>  
{
  /// <summary>
  /// Получить первичный ключ.
  /// </summary>
  /// <returns>Первичный ключ.</returns>
  public abstract string? GetPrimaryKey();

  /// <inheritdoc/>
  public sealed override string GetPrimaryKeyAsString()
  {
    return GetPrimaryKeyOrDefault();
  }

  /// <inheritdoc/>
  protected sealed override string GetDefaultPrimaryKey()
  {
    return string.Empty;
  }

  /// <inheritdoc/>
  protected sealed override string GetPrimaryKeyOrDefault()
  {
    return GetPrimaryKey() ?? GetDefaultPrimaryKey();
  }
}
