namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload;

/// <summary>
/// Расширения полезной нагрузки события приложения.
/// </summary>
public static class AppEventPayloadExtensions
{
  /// <summary>
  /// Преобразовать к объекту передачи данных одиночной полезной нагрузки события приложения.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  /// <returns>Объект передачи данных одиночной полезной нагрузки события приложения.</returns>
  public static AppEventPayloadSingleDTO ToAppEventPayloadSingleDTO(this AppEventPayloadEntity entity)
  {
    return new(entity.Id, entity.AppEventId, entity.Data);
  }

  /// <summary>
  /// Преобразовать к объекту передачи данных списка полезных нагрузок события приложения.
  /// </summary>
  /// <param name="items">Элементы.</param>
  /// <param name="totalCount">Общее количество.</param>
  /// <returns>Объект передачи данных списка полезных нагрузок события приложения.</returns>
  public static AppEventPayloadListDTO ToAppEventPayloadListDTO(
    this List<AppEventPayloadSingleDTO> items,
    long totalCount)
  {
    return new(items, totalCount);
  }

  /// <summary>
  /// Преобразовать к разделу порядка сортировки в запросе полезных нагрузок события приложения.
  /// </summary>
  /// <param name="field">Поле сортировки.</param>
  /// <param name="isDesc">Сортировать по убыванию?</param>
  /// <returns>Pаздел порядка сортировки в запросе.</returns>
  public static QueryOrderSection ToAppEventPayloadQueryOrderSection(this string? field, bool? isDesc)
  {
    field = (field ?? string.Empty).Trim();

    if (field == string.Empty)
    {
      field = AppEventPayloadSettings.DefaultQueryOrderSection.Field;
    }

    return new(field, isDesc ?? AppEventPayloadSettings.DefaultQueryOrderSection.IsDesc);
  }
}
