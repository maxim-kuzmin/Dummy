namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.AppOutgoingEventPayload;

/// <summary>
/// Расширения полезной нагрузки исходящего события приложения.
/// </summary>
public static class AppOutgoingEventPayloadExtensions
{
  /// <summary>
  /// Преобразовать к объекту передачи данных страницы полезных нагрузок исходящего события приложения.
  /// </summary>
  /// <param name="items">Элементы.</param>
  /// <param name="totalCount">Общее количество.</param>
  /// <returns>Объект передачи данных.</returns>
  public static AppOutgoingEventPayloadPageDTO ToAppOutgoingEventPayloadPageDTO(
    this List<AppOutgoingEventPayloadSingleDTO> items,
    long totalCount)
  {
    return new(Items: items, TotalCount: totalCount);
  }

  /// <summary>
  /// Преобразовать к разделу сортировки в запросе полезных нагрузок исходящего события приложения.
  /// </summary>
  /// <param name="field">Поле сортировки.</param>
  /// <param name="isDesc">Сортировать по убыванию?</param>
  /// <returns>Pаздел сортировки в запросе.</returns>
  public static QuerySortSection ToAppOutgoingEventPayloadQuerySortSection(this string? field, bool? isDesc)
  {
    field = (field ?? string.Empty).Trim();

    if (field == string.Empty)
    {
      field = AppOutgoingEventPayloadSettings.DefaultQuerySortSection.Field;
    }

    return new(Field: field, IsDesc: isDesc ?? AppOutgoingEventPayloadSettings.DefaultQuerySortSection.IsDesc);
  }
}
