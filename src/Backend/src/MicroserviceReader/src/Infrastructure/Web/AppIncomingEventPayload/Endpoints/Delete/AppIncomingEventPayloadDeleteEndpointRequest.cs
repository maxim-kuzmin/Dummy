namespace Makc.Dummy.MicroserviceReader.Infrastructure.Web.AppIncomingEventPayload.Endpoints.Delete;

/// <summary>
/// Запрос конечной точки удаления полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record AppIncomingEventPayloadDeleteEndpointRequest(string ObjectId);
