namespace Makc.Dummy.MicroserviceReader.Infrastructure.Web.DummyItem.Endpoints.Update;

/// <summary>
/// Запрос конечной точки создания фиктивного предмета.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
/// <param name="ConcurrencyToken">Токен параллелизма.</param>
public record DummyItemUpdateEndpointRequest(
  string ObjectId,
  long Id,
  string Name,
  string ConcurrencyToken);
