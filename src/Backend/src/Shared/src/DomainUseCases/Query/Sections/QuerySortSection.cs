namespace Makc.Dummy.Shared.DomainUseCases.Query.Sections;

/// <summary>
/// Раздел сортировки в запросе.
/// </summary>
/// <param name="Field">Поле.</param>
/// <param name="IsDesc">Сортировать по убыванию?</param>
public record QuerySortSection(string Field, bool IsDesc);
