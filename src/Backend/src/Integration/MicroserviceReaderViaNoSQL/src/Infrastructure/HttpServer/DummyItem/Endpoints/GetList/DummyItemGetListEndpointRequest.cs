namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.DummyItem.Endpoints.GetList;

/// <summary>
/// Запрос конечной точки получения списка фиктивных предметов.
/// </summary>
/// <param name="MaxCount">Макимальное количество.</param>
/// <param name="SortField">Поле сортировки.</param>
/// <param name="SortIsDesc">Сортировка по убыванию?</param>
/// <param name="Query">Запрос.</param>
public record DummyItemGetListEndpointRequest(
  int MaxCount,
  string? SortField,
  bool? SortIsDesc,
  string? Query);
