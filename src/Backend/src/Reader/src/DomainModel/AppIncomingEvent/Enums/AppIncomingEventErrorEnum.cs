namespace Makc.Dummy.Reader.DomainModel.AppIncomingEvent.Enums;

/// <summary>
/// Перечисление ошибок входящего события приложения.
/// </summary>
public enum AppIncomingEventErrorEnum
{
  /// <summary>
  /// Дата создания недействительна.
  /// </summary>
  CreatedAtIsInvalid,

  /// <summary>
  /// Дата загрузки недействительна.
  /// </summary>
  LoadedAtIsInvalid,

  /// <summary>
  /// Имя пустое.
  /// </summary>
  NameIsEmpty,

  /// <summary>
  /// Имя слишком длинное.
  /// </summary>
  NameIsTooLong,

  /// <summary>
  /// Дата обработки недействительна.
  /// </summary>
  ProcessedAtIsInvalid,
}
