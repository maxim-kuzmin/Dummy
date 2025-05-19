namespace Makc.Dummy.MicroserviceWriter.Apps.WebApp.DummyItem.Endpoints.Delete;

/// <summary>
/// Запрос конечной точки удаления фиктивного предмета.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record DummyItemDeleteEndpointRequest(long Id);
