namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEventPayload;

/// <summary>
/// Расширения полезной нагрузки входящего события приложения.
/// </summary>
public static class AppIncomingEventPayloadExtensions
{
  /// <summary>
  /// Преобразовать к объекту передачи данных списка полезных нагрузок входящего события приложения.
  /// </summary>
  /// <param name="items">Элементы.</param>
  /// <param name="totalCount">Общее количество.</param>
  /// <returns>Объект передачи данных списка полезных нагрузок входящего события приложения.</returns>
  public static AppIncomingEventPayloadListDTO ToAppIncomingEventPayloadListDTO(
    this List<AppIncomingEventPayloadSingleDTO> items,
    long totalCount)
  {
    return new(items, totalCount);
  }

  /// <summary>
  /// Преобразовать к разделу сортировки в запросе полезных нагрузок входящего события приложения.
  /// </summary>
  /// <param name="field">Поле сортировки.</param>
  /// <param name="isDesc">Сортировать по убыванию?</param>
  /// <returns>Pаздел сортировки в запросе.</returns>
  public static QuerySortSection ToAppIncomingEventPayloadQuerySortSection(this string? field, bool? isDesc)
  {
    field = (field ?? string.Empty).Trim();

    if (field == string.Empty)
    {
      field = AppIncomingEventPayloadSettings.DefaultQuerySortSection.Field;
    }

    return new(field, isDesc ?? AppIncomingEventPayloadSettings.DefaultQuerySortSection.IsDesc);
  }

  /// <summary>
  /// Преобразовать к объекту передачи данных одиночной полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  /// <returns>Объект передачи данных одиночной полезной нагрузки входящего события приложения.</returns>
  public static AppIncomingEventPayloadSingleDTO ToAppIncomingEventPayloadSingleDTO(
    this AppIncomingEventPayloadEntity entity)
  {
    return new(
      entity.Id,
      entity.AppIncomingEventId,
      entity.Data,
      entity.EntityConcurrencyTokenToDelete,
      entity.EntityConcurrencyTokenToInsert,
      entity.EntityId,
      entity.EntityName,
      entity.Position);
  }
}
