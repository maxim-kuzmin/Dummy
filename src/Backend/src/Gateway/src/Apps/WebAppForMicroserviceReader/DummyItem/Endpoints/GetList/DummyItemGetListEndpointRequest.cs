namespace Makc.Dummy.Gateway.Apps.WebAppForMicroserviceReader.DummyItem.Endpoints.GetList;

/// <summary>
/// Запрос конечной точки получения списка фиктивных предметов.
/// </summary>
/// <param name="CurrentPage">Текущая страница.</param>
/// <param name="ItemsPerPage">Количество записей на странице.</param>
/// <param name="SortField">Поле сортировки.</param>
/// <param name="SortIsDesc">Сортировка по убыванию?</param>
/// <param name="Query">Запрос.</param>
public record DummyItemGetListEndpointRequest(
  int CurrentPage,
  int ItemsPerPage,
  string? SortField,
  bool? SortIsDesc,
  string? Query);
