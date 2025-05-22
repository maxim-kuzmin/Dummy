namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.HttpServer.DummyItem.Endpoints.Get;

/// <summary>
/// Запрос конечной точки получения фиктивного предмета.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record DummyItemGetEndpointRequest(long Id);
