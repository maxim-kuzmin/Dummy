namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEvent;

/// <summary>
/// Расширения входящего события приложения.
/// </summary>
public static class AppIncomingEventExtensions
{
  /// <summary>
  /// Преобразовать к объекту передачи данных списка входящих событий приложения.
  /// </summary>
  /// <param name="items">Элементы.</param>
  /// <param name="totalCount">Общее количество.</param>
  /// <returns>Объект передачи данных списка входящих событий приложения.</returns>
  public static AppIncomingEventListDTO ToAppIncomingEventListDTO(this List<AppIncomingEventSingleDTO> items, long totalCount)
  {
    return new(items, totalCount);
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

    return new(field, isDesc ?? AppIncomingEventSettings.DefaultQuerySortSection.IsDesc);
  }

  /// <summary>
  /// Преобразовать к объекту передачи данных одиночного входящего события приложения.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  /// <returns>Объект передачи данных одиночного входящего события приложения.</returns>
  public static AppIncomingEventSingleDTO ToAppIncomingEventSingleDTO(this AppIncomingEventEntity entity)
  {
    return new(
      entity.ObjectId,
      entity.ConcurrencyToken,
      entity.CreatedAt,
      entity.EventId,
      entity.EventName,
      entity.LastLoadingAt,
      entity.LastLoadingError,
      entity.LoadedAt,
      entity.PayloadCount,
      entity.PayloadTotalCount,
      entity.ProcessedAt);
  }
}
