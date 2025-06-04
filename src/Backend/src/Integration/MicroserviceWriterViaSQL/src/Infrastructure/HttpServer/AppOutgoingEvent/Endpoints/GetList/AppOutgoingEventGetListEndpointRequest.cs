namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.HttpServer.AppOutgoingEvent.Endpoints.GetList;

/// <summary>
/// Запрос конечной точки получения списка исходящих событий приложения.
/// </summary>
/// <param name="MaxCount">Макимальное количество.</param>
/// <param name="SortField">Поле сортировки.</param>
/// <param name="SortIsDesc">Сортировка по убыванию?</param>
/// <param name="Query">Запрос.</param>
public record AppOutgoingEventGetListEndpointRequest(
  int MaxCount,
  string? SortField,
  bool? SortIsDesc,
  string? Query);
