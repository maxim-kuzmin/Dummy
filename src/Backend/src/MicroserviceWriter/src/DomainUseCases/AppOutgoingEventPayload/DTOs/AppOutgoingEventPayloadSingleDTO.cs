namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEventPayload.DTOs;

/// <summary>
/// Объект передачи данных действия по получению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="AppOutgoingEventId">Идентификатор исходящего события приложения.</param>
/// <param name="Data">Данные.</param>
/// <param name="EntityConcurrencyTokenToDelete">Токен параллелизма для удаления.</param>
/// <param name="EntityConcurrencyTokenToInsert">Токен параллелизма для вставки.</param>
/// <param name="EntityId">Идентификатор сущности.</param>
/// <param name="EntityName">Имя сущности.</param>
/// <param name="Position">Позиция.</param>
public record AppOutgoingEventPayloadSingleDTO(
  long Id,
  long AppOutgoingEventId,
  string? Data,
  string? EntityConcurrencyTokenToDelete,
  string? EntityConcurrencyTokenToInsert,
  string EntityId,
  string EntityName,
  int Position);
