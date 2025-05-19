namespace Makc.Dummy.MicroserviceReader.Apps.WebApp.DummyItem.Endpoints.Get;

/// <summary>
/// Запрос конечной точки получения фиктивного предмета.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record DummyItemGetEndpointRequest(string ObjectId);
