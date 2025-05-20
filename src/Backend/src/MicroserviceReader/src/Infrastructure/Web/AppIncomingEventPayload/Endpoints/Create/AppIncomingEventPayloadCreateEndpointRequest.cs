namespace Makc.Dummy.MicroserviceReader.Infrastructure.Web.AppIncomingEventPayload.Endpoints.Create;

/// <summary>
/// Запрос конечной точки создания полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="AppIncomingEventObjectId">Идентификатор объекта входящего события приложения.</param>
/// <param name="Payload">Полезная нагрузка.</param>
public record AppIncomingEventPayloadCreateEndpointRequest(
  string AppIncomingEventObjectId,
  AppEventPayloadWithDataAsString Payload);
