namespace Makc.Dummy.Shared.Domain.UseCases.Query.Sections;

/// <summary>
/// Раздел страницы в запросе.
/// </summary>
/// <param name="Number">Номер.</param>
/// <param name="Size">Размер.</param>
public record QueryPageSection(int Number, int Size);
