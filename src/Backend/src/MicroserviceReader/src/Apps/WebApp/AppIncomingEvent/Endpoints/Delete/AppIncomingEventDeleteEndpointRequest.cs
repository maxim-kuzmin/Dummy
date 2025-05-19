namespace Makc.Dummy.MicroserviceReader.Apps.WebApp.AppIncomingEvent.Endpoints.Delete;

/// <summary>
/// Запрос конечной точки удаления входящего события приложения.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record AppIncomingEventDeleteEndpointRequest(string ObjectId);
