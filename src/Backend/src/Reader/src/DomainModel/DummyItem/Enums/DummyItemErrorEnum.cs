namespace Makc.Dummy.Reader.DomainModel.DummyItem.Enums;

/// <summary>
/// Перечисление ошибок фиктивного предмета.
/// </summary>
public enum DummyItemErrorEnum
{
  /// <summary>
  /// Токен конкуренции недействителен.
  /// </summary>
  ConcurrencyTokenIsInvalid,
  /// <summary>
  /// Идентификатор недействителен.
  /// </summary>
  IdIsInvalid,
  /// <summary>
  /// Имя пустое.
  /// </summary>
  NameIsEmpty
}
