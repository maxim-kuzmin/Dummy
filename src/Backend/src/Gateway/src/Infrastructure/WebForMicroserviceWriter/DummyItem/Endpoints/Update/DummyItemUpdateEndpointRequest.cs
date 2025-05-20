namespace Makc.Dummy.Gateway.Infrastructure.WebForMicroserviceWriter.DummyItem.Endpoints.Update;

/// <summary>
/// Запрос конечной точки обновления фиктивного предмета.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
public record DummyItemUpdateEndpointRequest(
  long Id,
  string Name);
