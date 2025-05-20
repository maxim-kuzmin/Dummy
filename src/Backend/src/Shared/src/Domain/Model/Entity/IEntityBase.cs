namespace Makc.Dummy.Shared.Domain.Model.Entity;

/// <summary>
/// Интерфейс основы сущности.
/// </summary>
/// <typeparam name="TPrimaryKey">Тип первичного ключа.</typeparam>
public interface IEntityBase<TPrimaryKey> where TPrimaryKey : IEquatable<TPrimaryKey>
{
  /// <summary>
  /// Получить токен параллелизма.
  /// </summary>
  /// <returns>Токен параллелизма.</returns>
  string GetConcurrencyToken();

  /// <summary>
  /// Получить первичный ключ как строку.
  /// </summary>
  /// <returns>Строковое представление первичного ключа.</returns>
  string GetPrimaryKeyAsString();

  /// <summary>
  /// Содержит ли некорректный первичный ключ?
  /// </summary>
  /// <returns>Если некорректен, то true, иначе - false.</returns>
  public bool HasInvalidPrimaryKey();
}
