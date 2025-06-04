namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent;

/// <summary>
/// Расширения входящего события приложения.
/// </summary>
public static class AppIncomingEventExtensions
{
  /// <summary>
  /// Преобразовать к объекту передачи данных страницы входящих событий приложения.
  /// </summary>
  /// <param name="items">Элементы.</param>
  /// <param name="totalCount">Общее количество.</param>
  /// <returns>Объект передачи данных.</returns>
  public static AppIncomingEventPageDTO ToAppIncomingEventPageDTO(
    this List<AppIncomingEventSingleDTO> items,
    long totalCount)
  {
    return new(Items: items, TotalCount: totalCount);
  }

  /// <summary>
  /// Преобразовать к разделу сортировки в запросе входящих событий приложения.
  /// </summary>
  /// <param name="field">Поле сортировки.</param>
  /// <param name="isDesc">Сортировать по убыванию?</param>
  /// <returns>Pаздел сортировки в запросе.</returns>
  public static QuerySortSection ToAppIncomingEventQuerySortSection(this string? field, bool? isDesc)
  {
    field = (field ?? string.Empty).Trim();

    if (field == string.Empty)
    {
      field = AppIncomingEventSettings.DefaultQuerySortSection.Field;
    }

    return new(Field: field, IsDesc: isDesc ?? AppIncomingEventSettings.DefaultQuerySortSection.IsDesc);
  }
}
