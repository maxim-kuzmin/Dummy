namespace Makc.Dummy.MicroserviceWriter.Apps.WebApp.AppOutgoingEventPayload.Endpoints.Create;

/// <summary>
/// Запрос конечной точки обновления полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="AppOutgoingEventId">Идентификатор исходящего события приложения.</param>
/// <param name="Payload">Полезная нагрузка.</param>
public record AppOutgoingEventPayloadCreateEndpointRequest(
  long AppOutgoingEventId,
  AppEventPayloadWithDataAsString Payload);
