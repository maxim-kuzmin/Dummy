namespace Makc.Dummy.MicroserviceReader.Apps.WebApp.DummyItem.Endpoints.Create;

/// <summary>
/// Запрос конечной точки создания фиктивного предмета.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
/// <param name="ConcurrencyToken">Токен параллелизма.</param>
public record DummyItemCreateEndpointRequest(
  long Id,
  string Name,
  string ConcurrencyToken);
