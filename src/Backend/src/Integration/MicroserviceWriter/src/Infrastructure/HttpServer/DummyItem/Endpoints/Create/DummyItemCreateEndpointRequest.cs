namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.HttpServer.DummyItem.Endpoints.Create;

/// <summary>
/// Запрос конечной точки создания фиктивного предмета.
/// </summary>
/// <param name="Name">Имя.</param>
public record DummyItemCreateEndpointRequest(
  string Name);
