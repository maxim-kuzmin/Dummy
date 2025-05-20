namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEventPayload.Commands;

/// <summary>
/// Команда удаления полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record AppIncomingEventPayloadDeleteCommand(string ObjectId);
