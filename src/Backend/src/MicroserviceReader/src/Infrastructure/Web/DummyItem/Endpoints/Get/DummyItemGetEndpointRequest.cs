namespace Makc.Dummy.MicroserviceReader.Infrastructure.Web.DummyItem.Endpoints.Get;

/// <summary>
/// Запрос конечной точки получения фиктивного предмета.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record DummyItemGetEndpointRequest(string ObjectId);
