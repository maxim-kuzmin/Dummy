namespace Makc.Dummy.MicroserviceReader.Domain.Model.AppIncomingEvent.Enums;

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
  /// Последняя дата загрузки недействительна.
  /// </summary>
  LastLoadingAtIsInvalid,

  /// <summary>
  /// Последняя ошибка загрузки слишком длинная.
  /// </summary>
  LastLoadingErrorIsTooLong,

  /// <summary>
  /// Дата загрузки недействительна.
  /// </summary>
  LoadedAtIsInvalid,

  /// <summary>
  /// Количество полезной нагрузки отрицательное.
  /// </summary>
  PayloadCountIsNegative,

  /// <summary>
  /// Общее количество полезной нагрузки отрицательное.
  /// </summary>
  PayloadTotalCountIsNegative,

  /// <summary>
  /// Дата обработки недействительна.
  /// </summary>
  ProcessedAtIsInvalid,
}
