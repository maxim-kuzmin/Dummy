namespace Makc.Dummy.Shared.DomainModel.Entity.EntityBases;

/// <summary>
/// Основа сущности с первичным ключом в виде структуры.
/// </summary>
/// <typeparam name="TPrimaryKey">Тип первичного ключа.</typeparam>
public abstract class EntityBaseWithStructPrimaryKey<TPrimaryKey> : EntityBase<TPrimaryKey>
  where TPrimaryKey : struct, IEquatable<TPrimaryKey>
{
  /// <inheritdoc/>
  public sealed override TPrimaryKey GetDefaultPrimaryKey()
  {
    return default;
  }

  /// <summary>
  /// Получить первичный ключ.
  /// </summary>
  /// <returns>Первичный ключ.</returns>
  public abstract TPrimaryKey GetPrimaryKey();

  /// <inheritdoc/>
  public sealed override TPrimaryKey GetPrimaryKeyOrDefault()
  {
    return GetPrimaryKey();
  }
}
