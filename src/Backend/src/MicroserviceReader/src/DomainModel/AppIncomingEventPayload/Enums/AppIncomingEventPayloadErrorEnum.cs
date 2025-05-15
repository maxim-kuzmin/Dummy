namespace Makc.Dummy.MicroserviceReader.DomainModel.AppIncomingEventPayload.Enums;

/// <summary>
/// Перечисление ошибок полезной нагрузки входящего события приложения.
/// </summary>
public enum AppIncomingEventPayloadErrorEnum
{
  /// <summary>
  /// Идентификатор входящего события приложения пуст.
  /// </summary>
  AppIncomingEventIdIsEmpty,

  /// <summary>
  /// Идентификатор входящего события приложения слишком длинный.
  /// </summary>
  AppIncomingEventIdIsTooLong,

  /// <summary>
  /// Дата создания недействительна.
  /// </summary>
  CreatedAtIsInvalid,

  /// <summary>
  /// Данные слишком длинные.
  /// </summary>
  DataIsTooLong,

  /// <summary>
  /// Токен параллелизма сущности для удаления слишком длинный.
  /// </summary>
  EntityConcurrencyTokenToDeleteIsTooLong,

  /// <summary>
  /// Токен параллелизма сущности для вставки слишком длинный.
  /// </summary>
  EntityConcurrencyTokenToInsertIsTooLong,

  /// <summary>
  /// Идентификатор сущности пуст.
  /// </summary>
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
  /// Идентификатор полезной нагрузки события пуст.
  EventPayloadIdIsEmpty,

  /// <summary>
  /// Идентификатор полезной нагрузки события слишком длинный.
  /// </summary>
  EventPayloadIdTooLong,

  /// <summary>
  /// Позиция является отрицательным числом.
  /// </summary>
  PositionIsNegative,
}
