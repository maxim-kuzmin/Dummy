namespace Makc.Dummy.Reader.DomainModel.AppIncomingEventPayload.Enums;

/// <summary>
/// Перечисление ошибок полезной нагрузки входящего события приложения.
/// </summary>
public enum AppIncomingEventPayloadErrorEnum
{
  /// <summary>
  /// Идентификатор события недействителен.
  /// </summary>
  AppIncomingEventIdIsInvalid,

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
