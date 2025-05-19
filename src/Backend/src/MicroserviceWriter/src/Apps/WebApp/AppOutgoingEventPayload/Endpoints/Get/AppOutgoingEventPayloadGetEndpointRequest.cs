namespace Makc.Dummy.MicroserviceWriter.Apps.WebApp.AppOutgoingEventPayload.Endpoints.Get;

/// <summary>
/// Запрос конечной точки получения полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record AppOutgoingEventPayloadGetEndpointRequest(long Id);
