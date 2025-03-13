namespace Makc.Dummy.Reader.DomainUseCases.DummyItem;

/// <summary>
/// Расширения фиктивного предмета.
/// </summary>
public static class DummyItemExtensions
{
  /// <summary>
  /// Преобразовать к объекту передачи данных списка фиктивных предметов.
  /// </summary>
  /// <param name="items">Элементы.</param>
  /// <param name="totalCount">Общее количество.</param>
  /// <returns>Объект передачи данных списка фиктивных предметов.</returns>
  public static DummyItemListDTO ToDummyItemListDTO(this List<DummyItemSingleDTO> items, long totalCount)
  {
    return new(items, totalCount);
  }

  /// <summary>
  /// Преобразовать к разделу сортировки в запросе фиктивных предметов.
  /// </summary>
  /// <param name="field">Поле сортировки.</param>
  /// <param name="isDesc">Сортировать по убыванию?</param>
  /// <returns>Pаздел сортировки в запросе.</returns>
  public static QuerySortSection ToDummyItemQuerySortSection(this string? field, bool? isDesc)
  {
    field = (field ?? string.Empty).Trim();

    if (field == string.Empty)
    {
      field = DummyItemSettings.DefaultQuerySortSection.Field;
    }

    return new(field, isDesc ?? DummyItemSettings.DefaultQuerySortSection.IsDesc);
  }

  /// <summary>
  /// Преобразовать к объекту передачи данных одиночного фиктивного предмета.
  /// </summary>
  /// <param name="entity">Сущность.</param>
  /// <returns>Объект передачи данных одиночного фиктивного предмета.</returns>
  public static DummyItemSingleDTO ToDummyItemSingleDTO(this DummyItemEntity entity)
  {
    return new(entity.Id, entity.Name);
  }
}
