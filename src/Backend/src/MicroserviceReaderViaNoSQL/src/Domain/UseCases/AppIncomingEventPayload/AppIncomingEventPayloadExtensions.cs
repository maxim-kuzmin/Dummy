﻿namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEventPayload;

/// <summary>
/// Расширения полезной нагрузки входящего события приложения.
/// </summary>
public static class AppIncomingEventPayloadExtensions
{
  /// <summary>
  /// Преобразовать к объекту передачи данных единственной полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  /// <returns>Объект передачи данных.</returns>
  public static AppIncomingEventPayloadSingleDTO ToAppIncomingEventPayloadSingleDTO(
    this AppIncomingEventPayloadEntity entity)
  {
    return new()
    {
      ObjectId = entity.ObjectId,
      CreatedAt = entity.CreatedAt,
      ConcurrencyToken = entity.ConcurrencyToken,
      AppIncomingEventObjectId = entity.AppIncomingEventObjectId,
      Data = entity.Data,
      EntityConcurrencyTokenToDelete = entity.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert = entity.EntityConcurrencyTokenToInsert,
      EntityId = entity.EntityId,
      EntityName = entity.EntityName,
      EventPayloadId = entity.EventPayloadId,
      Position = entity.Position,
    };
  }
}
