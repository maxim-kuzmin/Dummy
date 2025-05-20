namespace Makc.Dummy.MicroserviceWriter.Infrastructure.Web.AppOutgoingEventPayload.Endpoints.Delete;

/// <summary>
/// Запрос конечной точки удаления полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record AppOutgoingEventPayloadDeleteEndpointRequest(long Id);
