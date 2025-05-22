namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCases.AppIncomingEventPayload.Queries;

/// <summary>
/// Запрос единственной полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record AppIncomingEventPayloadSingleQuery(string? ObjectId);
