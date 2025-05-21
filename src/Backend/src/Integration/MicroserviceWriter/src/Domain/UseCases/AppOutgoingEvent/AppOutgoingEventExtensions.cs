namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent;

/// <summary>
/// Расширения исходящего события приложения.
/// </summary>
public static class AppOutgoingEventExtensions
{
  /// <summary>
  /// Преобразовать к объекту передачи данных страницы исходящих событий приложения.
  /// </summary>
  /// <param name="items">Элементы.</param>
  /// <param name="totalCount">Общее количество.</param>
  /// <returns>Объект передачи данных.</returns>
  public static AppOutgoingEventPageDTO ToAppOutgoingEventPageDTO(
    this List<AppOutgoingEventSingleDTO> items,
    long totalCount)
  {
    return new(Items: items, TotalCount: totalCount);
  }

  /// <summary>
  /// Преобразовать к разделу сортировки в запросе исходящих событий приложения.
  /// </summary>
  /// <param name="field">Поле сортировки.</param>
  /// <param name="isDesc">Сортировать по убыванию?</param>
  /// <returns>Pаздел сортировки в запросе.</returns>
  public static QuerySortSection ToAppOutgoingEventQuerySortSection(this string? field, bool? isDesc)
  {
    field = (field ?? string.Empty).Trim();

    if (field == string.Empty)
    {
      field = AppOutgoingEventSettings.DefaultQuerySortSection.Field;
    }

    return new(Field: field, IsDesc: isDesc ?? AppOutgoingEventSettings.DefaultQuerySortSection.IsDesc);
  }
}
