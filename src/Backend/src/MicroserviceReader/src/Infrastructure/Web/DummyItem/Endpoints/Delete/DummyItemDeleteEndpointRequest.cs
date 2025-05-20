namespace Makc.Dummy.MicroserviceReader.Infrastructure.Web.DummyItem.Endpoints.Delete;

/// <summary>
/// Запрос конечной точки удаления фиктивного предмета.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record DummyItemDeleteEndpointRequest(string ObjectId);
