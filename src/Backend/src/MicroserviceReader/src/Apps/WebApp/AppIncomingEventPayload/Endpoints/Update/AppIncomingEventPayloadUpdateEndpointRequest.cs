namespace Makc.Dummy.MicroserviceReader.Apps.WebApp.AppIncomingEventPayload.Endpoints.Update;

/// <summary>
/// Запрос конечной точки создания полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
/// <param name="AppIncomingEventObjectId">Идентификатор объекта входящего события приложения.</param>
/// <param name="Payload">Полезная нагрузка.</param>
public record AppIncomingEventPayloadUpdateEndpointRequest(
  string ObjectId,
  string AppIncomingEventObjectId,
  AppEventPayloadWithDataAsString Payload);
