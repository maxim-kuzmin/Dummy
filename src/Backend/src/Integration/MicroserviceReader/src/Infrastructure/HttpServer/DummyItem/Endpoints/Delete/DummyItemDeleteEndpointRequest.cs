namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.HttpServer.DummyItem.Endpoints.Delete;

/// <summary>
/// Запрос конечной точки удаления фиктивного предмета.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record DummyItemDeleteEndpointRequest(string ObjectId);
