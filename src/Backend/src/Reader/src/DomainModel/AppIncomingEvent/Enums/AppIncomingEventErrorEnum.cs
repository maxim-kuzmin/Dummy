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
  /// Идентификатор события пустой.
  /// </summary>
  EventIdIsEmpty,

  /// <summary>
  /// Идентификатор события слишком длинный.
  /// </summary>
  EventIdIsTooLong,

  /// <summary>
  /// Имя события пустое.
  /// </summary>
  EventNameIsEmpty,

  /// <summary>
  /// Имя события слишком длинное.
  /// </summary>
  EventNameIsTooLong,

  /// <summary>
  /// Дата загрузки недействительна.
  /// </summary>
  LoadedAtIsInvalid,

  /// <summary>
  /// Дата обработки недействительна.
  /// </summary>
  ProcessedAtIsInvalid,
}
