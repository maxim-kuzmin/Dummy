namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent;

/// <summary>
/// Расширения исходящего события приложения.
/// </summary>
public static class AppOutgoingEventExtensions
{
  /// <summary>
  /// Преобразовать к объекту передачи данных списка исходящих событий приложения.
  /// </summary>
  /// <param name="items">Элементы.</param>
  /// <param name="totalCount">Общее количество.</param>
  /// <returns>Объект передачи данных списка исходящих событий приложения.</returns>
  public static AppOutgoingEventListDTO ToAppOutgoingEventListDTO(
    this List<AppOutgoingEventSingleDTO> items,
    long totalCount)
  {
    return new(items, totalCount);
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

    return new(field, isDesc ?? AppOutgoingEventSettings.DefaultQuerySortSection.IsDesc);
  }

  /// <summary>
  /// Преобразовать к объекту передачи данных одиночного исходящего события приложения.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  /// <returns>Объект передачи данных одиночного исходящего события приложения.</returns>
  public static AppOutgoingEventSingleDTO ToAppOutgoingEventSingleDTO(this AppOutgoingEventEntity entity)
  {
    return new(entity.Id, entity.CreatedAt, entity.Name, entity.PublishedAt);
  }
}
