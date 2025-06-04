namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.AppIncomingEventPayload.Endpoints.Get;

/// <summary>
/// Запрос конечной точки получения полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record AppIncomingEventPayloadGetEndpointRequest(string ObjectId);
