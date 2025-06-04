namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.HttpServer.AppOutgoingEvent.Endpoints.GetPage;

/// <summary>
/// Запрос конечной точки получения списка исходящих событий приложения.
/// </summary>
/// <param name="CurrentPage">Текущая страница.</param>
/// <param name="ItemsPerPage">Количество записей на странице.</param>
/// <param name="SortField">Поле сортировки.</param>
/// <param name="SortIsDesc">Сортировка по убыванию?</param>
/// <param name="Query">Запрос.</param>
public record AppOutgoingEventGetPageEndpointRequest(
  int CurrentPage,
  int ItemsPerPage,
  string? SortField,
  bool? SortIsDesc,
  string? Query);
