namespace Makc.Dummy.MicroserviceReader.Apps.WebApp.AppIncomingEvent.Endpoints.Get;

/// <summary>
/// Запрос конечной точки получения входящего события приложения.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record AppIncomingEventGetEndpointRequest(string ObjectId);
