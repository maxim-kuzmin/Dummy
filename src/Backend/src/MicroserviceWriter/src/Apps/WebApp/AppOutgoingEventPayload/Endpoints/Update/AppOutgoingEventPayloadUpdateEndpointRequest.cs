namespace Makc.Dummy.MicroserviceWriter.Apps.WebApp.AppOutgoingEventPayload.Endpoints.Update;

/// <summary>
/// Запрос конечной точки обновления полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="AppOutgoingEventId">Идентификатор исходящего события приложения.</param>
/// <param name="Payload">Полезная нагрузка.</param>
public record AppOutgoingEventPayloadUpdateEndpointRequest(
  long Id,
  long AppOutgoingEventId,
  AppEventPayloadWithDataAsString Payload);
