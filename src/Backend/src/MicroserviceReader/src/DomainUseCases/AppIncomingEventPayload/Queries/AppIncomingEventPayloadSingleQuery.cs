namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEventPayload.Queries;

/// <summary>
/// Запрос единственной полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record AppIncomingEventPayloadSingleQuery(string? ObjectId);
