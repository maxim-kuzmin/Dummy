namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCases.DummyItem;

/// <summary>
/// Расширения фиктивного предмета.
/// </summary>
public static class DummyItemExtensions
{
  /// <summary>
  /// Преобразовать к объекту передачи данных страницы фиктивных предметов.
  /// </summary>
  /// <param name="items">Элементы.</param>
  /// <param name="totalCount">Общее количество.</param>
  /// <returns>Объект передачи данных.</returns>
  public static DummyItemPageDTO ToDummyItemPageDTO(this List<DummyItemSingleDTO> items, long totalCount)
  {
    return new(Items: items, TotalCount: totalCount);
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

    return new(Field: field, IsDesc: isDesc ?? DummyItemSettings.DefaultQuerySortSection.IsDesc);
  }
}
