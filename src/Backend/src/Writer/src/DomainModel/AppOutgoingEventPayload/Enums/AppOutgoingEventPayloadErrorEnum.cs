namespace Makc.Dummy.Writer.DomainModel.AppOutgoingEventPayload.Enums;

/// <summary>
/// Перечисление ошибок полезной нагрузки исходящего события приложения.
/// </summary>
public enum AppOutgoingEventPayloadErrorEnum
{
  /// <summary>
  /// Идентификатор события недействителен.
  /// </summary>
  AppOutgoingEventIdIsInvalid,

  /// <summary>
  /// Данные пустые.
  /// </summary>
  DataIsEmpty,

  /// <summary>
  /// Данные слишком длинные.
  /// </summary>
  DataIsTooLong
}
