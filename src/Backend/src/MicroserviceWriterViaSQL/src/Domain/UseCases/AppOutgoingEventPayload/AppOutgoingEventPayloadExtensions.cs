namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEventPayload;

/// <summary>
/// Расширения полезной нагрузки исходящего события приложения.
/// </summary>
public static class AppOutgoingEventPayloadExtensions
{
  /// <summary>
  /// Преобразовать к объекту передачи данных единственной полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  /// <returns>Объект передачи данных.</returns>
  public static AppOutgoingEventPayloadSingleDTO ToAppOutgoingEventPayloadSingleDTO(
    this AppOutgoingEventPayloadEntity entity)
  {
    return new()
    {
      Id = entity.Id,
      ConcurrencyToken = entity.ConcurrencyToken,
      AppOutgoingEventId = entity.AppOutgoingEventId,
      Data = entity.Data,
      EntityConcurrencyTokenToDelete = entity.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert = entity.EntityConcurrencyTokenToInsert,
      EntityId = entity.EntityId,
      EntityName = entity.EntityName,
      Position = entity.Position,
    };
  }
}
