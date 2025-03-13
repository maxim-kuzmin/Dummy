namespace Makc.Dummy.Writer.DomainUseCases.AppEvent;

/// <summary>
/// Расширения события приложения.
/// </summary>
public static class AppEventExtensions
{
  /// <summary>
  /// Преобразовать к объекту передачи данных одиночного события приложения.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  /// <returns>Объект передачи данных одиночного события приложения.</returns>
  public static AppEventSingleDTO ToAppEventSingleDTO(this AppEventEntity entity)
  {
    return new(entity.Id, entity.CreatedAt, entity.IsPublished, entity.Name);
  }

  /// <summary>
  /// Преобразовать к объекту передачи данных списка событий приложения.
  /// </summary>
  /// <param name="items">Элементы.</param>
  /// <param name="totalCount">Общее количество.</param>
  /// <returns>Объект передачи данных списка событий приложения.</returns>
  public static AppEventListDTO ToAppEventListDTO(this List<AppEventSingleDTO> items, long totalCount)
  {
    return new(items, totalCount);
  }

  /// <summary>
  /// Преобразовать к разделу порядка сортировки в запросе событий приложения.
  /// </summary>
  /// <param name="field">Поле сортировки.</param>
  /// <param name="isDesc">Сортировать по убыванию?</param>
  /// <returns>Pаздел порядка сортировки в запросе.</returns>
  public static QueryOrderSection ToAppEventQueryOrderSection(this string? field, bool? isDesc)
  {
    field = (field ?? string.Empty).Trim();

    if (field == string.Empty)
    {
      field = nameof(AppEventEntity.Id);
    }

    return new(field, isDesc ?? true);
  }
}
