namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEventPayload.Commands;

/// <summary>
/// Команда удаления полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record AppOutgoingEventPayloadDeleteCommand(long Id);
