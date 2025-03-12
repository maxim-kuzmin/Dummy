namespace Makc.Dummy.Shared.DomainUseCases.Query.Sections;

/// <summary>
/// Раздел порядка сортировки в запросе.
/// </summary>
/// <param name="Field">Поле.</param>
/// <param name="IsDesc">Сортировать по убыванию?</param>
public record QueryOrderSection(string Field, bool IsDesc);
