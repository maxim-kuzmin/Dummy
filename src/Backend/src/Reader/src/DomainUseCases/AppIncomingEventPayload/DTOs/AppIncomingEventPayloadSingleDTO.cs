namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEventPayload.DTOs;

/// <summary>
/// Объект передачи данных действия по получению полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
/// <param name="AppIncomingEventId">Идентификатор входящего события приложения.</param>
/// <param name="Data">Данные.</param>
/// <param name="EntityConcurrencyTokenToDelete">Токен параллелизма для удаления.</param>
/// <param name="EntityConcurrencyTokenToInsert">Токен параллелизма для вставки.</param>
/// <param name="EntityId">Идентификатор сущности.</param>
/// <param name="EntityName">Имя сущности.</param>
/// <param name="EventPayloadId">Идентификатор полезной нагрузки события.</param>
/// <param name="Position">Позиция.</param>
public record AppIncomingEventPayloadSingleDTO(
  string? ObjectId,
  string AppIncomingEventId,
  string? Data,
  string? EntityConcurrencyTokenToDelete,
  string? EntityConcurrencyTokenToInsert,
  string EntityId,
  string EntityName,
  string EventPayloadId,
  int Position);
