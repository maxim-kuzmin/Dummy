namespace Makc.Dummy.Writer.DomainModel.AppEventPayload.Enums;

/// <summary>
/// Перечисление ошибок полезной нагрузки события приложения.
/// </summary>
public enum AppEventPayloadErrorEnum
{
  /// <summary>
  /// Идентификатор события недействителен.
  /// </summary>
  AppEventIdIsInvalid,

  /// <summary>
  /// Данные пустые.
  /// </summary>
  DataIsEmpty,

  /// <summary>
  /// Данные слишком длинные.
  /// </summary>
  DataIsTooLong
}
