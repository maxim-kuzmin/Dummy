namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEventPayload;

/// <summary>
/// Расширения полезной нагрузки исходящего события приложения.
/// </summary>
public static class AppOutgoingEventPayloadExtensions
{
  /// <summary>
  /// Преобразовать к объекту передачи данных списка полезных нагрузок исходящего события приложения.
  /// </summary>
  /// <param name="items">Элементы.</param>
  /// <param name="totalCount">Общее количество.</param>
  /// <returns>Объект передачи данных списка полезных нагрузок исходящего события приложения.</returns>
  public static AppOutgoingEventPayloadListDTO ToAppOutgoingEventPayloadListDTO(
    this List<AppOutgoingEventPayloadSingleDTO> items,
    long totalCount)
  {
    return new(items, totalCount);
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

    return new(field, isDesc ?? AppOutgoingEventPayloadSettings.DefaultQuerySortSection.IsDesc);
  }

  /// <summary>
  /// Преобразовать к объекту передачи данных одиночной полезной нагрузки исходящего события приложения.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  /// <returns>Объект передачи данных одиночной полезной нагрузки исходящего события приложения.</returns>
  public static AppOutgoingEventPayloadSingleDTO ToAppOutgoingEventPayloadSingleDTO(this AppOutgoingEventPayloadEntity entity)
  {
    return new(
      entity.Id,
      entity.AppOutgoingEventId,
      entity.Data,
      entity.EntityConcurrencyTokenToDelete,
      entity.EntityConcurrencyTokenToInsert,
      entity.EntityId,
      entity.EntityName,
      entity.Position);
  }
}
