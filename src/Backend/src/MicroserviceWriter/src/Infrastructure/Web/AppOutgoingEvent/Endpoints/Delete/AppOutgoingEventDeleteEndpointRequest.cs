namespace Makc.Dummy.MicroserviceWriter.Infrastructure.Web.AppOutgoingEvent.Endpoints.Delete;

/// <summary>
/// Запрос конечной точки удаления исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record AppOutgoingEventDeleteEndpointRequest(long Id);
