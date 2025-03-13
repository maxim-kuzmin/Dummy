namespace Makc.Dummy.Writer.DomainUseCases.AppEvent.Query.Sections;

/// <summary>
/// Раздел фильтра запроса событий приложения.
/// </summary>
/// <param name="FullTextSearchQuery">Запрос полнотекстового поиска.</param>
public record AppEventQueryFilterSection(string? FullTextSearchQuery);
