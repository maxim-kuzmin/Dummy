namespace Makc.Dummy.Shared.DomainModel.Entity;

/// <summary>
/// Основа сущности.
/// </summary>
/// <typeparam name="TPrimaryKey">Тип первичного ключа.</typeparam>
public abstract class EntityBase<TPrimaryKey> : IEntityBase<TPrimaryKey>
  where TPrimaryKey : IEquatable<TPrimaryKey>
{
  /// <inheritdoc/>
  public abstract string GetConcurrencyToken();

  /// <inheritdoc/>
  public abstract string GetPrimaryKeyAsString();

  /// <inheritdoc/>
  public bool HasInvalidPrimaryKey()
  {
    return GetPrimaryKeyOrDefault().Equals(GetDefaultPrimaryKey());
  }

  /// <summary>
  /// Получить первичный ключ по умолчанию.
  /// </summary>
  /// <returns>Первичный ключ по умолчанию.</returns>
  protected abstract TPrimaryKey GetDefaultPrimaryKey();

  /// <summary>
  /// Получить первичный ключ или значение по умолчанию, если первичный ключ не определён.
  /// </summary>
  /// <returns>Первичный ключ.</returns>
  protected abstract TPrimaryKey GetPrimaryKeyOrDefault();
}
