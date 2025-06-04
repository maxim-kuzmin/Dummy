namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.AppIncomingEventPayload.Endpoints.Create;

/// <summary>
/// Запрос конечной точки создания полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="AppIncomingEventObjectId">Идентификатор объекта входящего события приложения.</param>
/// <param name="EventPayloadId">Идентификатор полезной нагрузки события.</param>
/// <param name="Payload">Полезная нагрузка.</param>
public record AppIncomingEventPayloadCreateEndpointRequest(
  string AppIncomingEventObjectId,
  string EventPayloadId,
  AppEventPayloadWithDataAsString Payload);
