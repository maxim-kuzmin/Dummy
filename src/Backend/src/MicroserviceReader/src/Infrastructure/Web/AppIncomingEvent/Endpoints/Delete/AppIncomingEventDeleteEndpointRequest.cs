namespace Makc.Dummy.MicroserviceReader.Infrastructure.Web.AppIncomingEvent.Endpoints.Delete;

/// <summary>
/// Запрос конечной точки удаления входящего события приложения.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record AppIncomingEventDeleteEndpointRequest(string ObjectId);
