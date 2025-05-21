namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.AppOutgoingEventPayload.Commands;

/// <summary>
/// Команда удаления полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record AppOutgoingEventPayloadDeleteCommand(long Id);
