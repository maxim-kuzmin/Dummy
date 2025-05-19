namespace Makc.Dummy.MicroserviceReader.Apps.WebApp.AppIncomingEventPayload.Endpoints.Delete;

/// <summary>
/// Запрос конечной точки удаления полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record AppIncomingEventPayloadDeleteEndpointRequest(string ObjectId);
