namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.HttpServer.AppOutgoingEventPayload.Endpoints.GetList;

/// <summary>
/// Запрос конечной точки получения списка полезных нагрузок исходящего события приложения.
/// </summary>
/// <param name="MaxCount">Макимальное количество.</param>
/// <param name="SortField">Поле сортировки.</param>
/// <param name="SortIsDesc">Сортировка по убыванию?</param>
/// <param name="Query">Запрос.</param>
public record AppOutgoingEventPayloadGetListEndpointRequest(
  int MaxCount,
  string? SortField,
  bool? SortIsDesc,
  string? Query);
