namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.AppIncomingEventPayload.Endpoints.GetList;

/// <summary>
/// Запрос конечной точки получения списка полезных нагрузок входящего события приложения.
/// </summary>
/// <param name="MaxCount">Макимальное количество.</param>
/// <param name="SortField">Поле сортировки.</param>
/// <param name="SortIsDesc">Сортировка по убыванию?</param>
/// <param name="Query">Запрос.</param>
public record AppIncomingEventPayloadGetListEndpointRequest(
  int MaxCount,
  string? SortField,
  bool? SortIsDesc,
  string? Query);
