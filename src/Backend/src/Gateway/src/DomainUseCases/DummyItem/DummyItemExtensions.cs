namespace Makc.Dummy.Gateway.DomainUseCases.DummyItem;

/// <summary>
/// Расширения фиктивного предмета.
/// </summary>
public static class DummyItemExtensions
{
  /// <summary>
  /// Преобразовать к разделу порядка сортировки в запросе фиктивных предметов.
  /// </summary>
  /// <param name="field">Поле сортировки.</param>
  /// <param name="isDesc">Сортировать по убыванию?</param>
  /// <returns>Pаздел порядка сортировки в запросе.</returns>
  public static QueryOrderSection ToDummyItemQueryOrderSection(this string? field, bool? isDesc)
  {
    field = (field ?? string.Empty).Trim();

    if (field == string.Empty)
    {
      field = DummyItemSettings.DefaultQueryOrderSection.Field;
    }

    return new(field, isDesc ?? DummyItemSettings.DefaultQueryOrderSection.IsDesc);
  }
}
