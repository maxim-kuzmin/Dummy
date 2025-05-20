namespace Makc.Dummy.Shared.Domain.Model.Entity.EntityBases;

/// <summary>
/// Основа сущности с первичным ключом в виде структуры.
/// </summary>
/// <typeparam name="TPrimaryKey">Тип первичного ключа.</typeparam>
public abstract class EntityBaseWithStructPrimaryKey<TPrimaryKey> : EntityBase<TPrimaryKey>
  where TPrimaryKey : struct, IEquatable<TPrimaryKey>
{
  /// <summary>
  /// Получить первичный ключ.
  /// </summary>
  /// <returns>Первичный ключ.</returns>
  public abstract TPrimaryKey GetPrimaryKey();

  /// <inheritdoc/>
  public sealed override string GetPrimaryKeyAsString()
  {
    return GetPrimaryKey().ToString() ?? string.Empty;
  }

  /// <inheritdoc/>
  protected sealed override TPrimaryKey GetDefaultPrimaryKey()
  {
    return default;
  }

  /// <inheritdoc/>
  protected sealed override TPrimaryKey GetPrimaryKeyOrDefault()
  {
    return GetPrimaryKey();
  }
}
