namespace Makc.Dummy.MicroserviceWriter.Infrastructure.Web.AppOutgoingEvent.Endpoints.Get;

/// <summary>
/// Запрос конечной точки получения исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record AppOutgoingEventGetEndpointRequest(long Id);
