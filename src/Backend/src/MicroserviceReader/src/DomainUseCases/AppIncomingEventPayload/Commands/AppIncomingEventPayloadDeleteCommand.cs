namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEventPayload.Commands;

/// <summary>
/// Команда удаления полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record AppIncomingEventPayloadDeleteCommand(string ObjectId);
