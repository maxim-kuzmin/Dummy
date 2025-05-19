namespace Makc.Dummy.MicroserviceWriter.Apps.WebApp.AppOutgoingEvent.Endpoints.Delete;

/// <summary>
/// Запрос конечной точки удаления исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record AppOutgoingEventDeleteEndpointRequest(long Id);
