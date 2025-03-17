namespace Makc.Dummy.Gateway.DomainUseCasesForWriter.DummyItem;

/// <summary>
/// Расширения фиктивного предмета.
/// </summary>
public static class DummyItemExtensions
{
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
}
