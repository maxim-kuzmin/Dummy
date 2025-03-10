namespace Makc.Dummy.Shared.DomainModel.Entity;

/// <summary>
/// Интерфейс основы сущности.
/// </summary>
/// <typeparam name="TPrimaryKey">Тип первичного ключа.</typeparam>
public interface IEntityBase<TPrimaryKey> : IDeepCopyable
  where TPrimaryKey : IEquatable<TPrimaryKey>
{
  /// <summary>
  /// Получить первичный ключ по умолчанию.
  /// </summary>
  /// <returns>Первичный ключ по умолчанию.</returns>
  TPrimaryKey GetDefaultPrimaryKey();

  /// <summary>
  /// Получить первичный ключ.
  /// </summary>
  /// <returns>Первичный ключ.</returns>
  TPrimaryKey GetPrimaryKey();
}
