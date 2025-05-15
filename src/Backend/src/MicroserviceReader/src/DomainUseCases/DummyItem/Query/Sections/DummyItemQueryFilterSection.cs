namespace Makc.Dummy.MicroserviceReader.DomainUseCases.DummyItem.Query.Sections;

/// <summary>
/// Раздел фильтра запроса фиктивных предметов.
/// </summary>
/// <param name="FullTextSearchQuery">Запрос полнотекстового поиска.</param>
public record DummyItemQueryFilterSection(string? FullTextSearchQuery);
