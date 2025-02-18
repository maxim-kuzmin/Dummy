namespace Makc.Dummy.Writer.DomainModel.AppEvent.Enums;

/// <summary>
/// Перечисление ошибок события приложения.
/// </summary>
public enum AppEventErrorEnum
{
  /// <summary>
  /// Дата создания недействительна.
  /// </summary>
  CreatedAtIsInvalid,

  /// <summary>
  /// Имя пустое.
  /// </summary>
  NameIsEmpty,

  /// <summary>
  /// Имя слишком длинное.
  /// </summary>
  NameIsTooLong
}
