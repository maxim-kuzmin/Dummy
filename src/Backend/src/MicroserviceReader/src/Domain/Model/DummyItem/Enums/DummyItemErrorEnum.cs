namespace Makc.Dummy.MicroserviceReader.Domain.Model.DummyItem.Enums;

/// <summary>
/// Перечисление ошибок фиктивного предмета.
/// </summary>
public enum DummyItemErrorEnum
{
  /// <summary>
  /// Токен параллелизма недействителен.
  /// </summary>
  ConcurrencyTokenIsInvalid,

  /// <summary>
  /// Идентификатор недействителен.
  /// </summary>
  IdIsInvalid,

  /// <summary>
  /// Имя пустое.
  /// </summary>
  NameIsEmpty,

  /// <summary>
  /// Имя слишком длинное.
  /// </summary>
  NameIsTooLong
}
