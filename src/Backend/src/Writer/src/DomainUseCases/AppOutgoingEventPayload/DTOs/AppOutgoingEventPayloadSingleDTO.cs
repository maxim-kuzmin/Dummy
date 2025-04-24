namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEventPayload.DTOs;

/// <summary>
/// Объект передачи данных действия по получению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="AppOutgoingEventId">Идентификатор исходящего события приложения.</param>
/// <param name="Data">Данные.</param>
public record AppOutgoingEventPayloadSingleDTO(long Id, long AppOutgoingEventId, string Data);
