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
  DataIsTooLong,

  /// <summary>
  /// Идентификатор сущности пуст.
  EntityIdIsEmpty,

  /// <summary>
  /// Идентификатор сущности слишком длинный.
  /// </summary>
  EntityIdTooLong,

  /// <summary>
  /// Имя сущности пустое.
  /// </summary>
  EntityNameIsEmpty,

  /// <summary>
  /// Имя сущности слишком длинное.
  /// </summary>
  EntityNameTooLong,

  /// <summary>
  /// Позиция не является положительным числом.
  /// </summary>
  PositionIsNotPositiveNumber,
}
