namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.Query.Sections;

/// <summary>
/// Раздел фильтра запроса исходящих событий приложения.
/// </summary>
/// <param name="FullTextSearchQuery">Запрос полнотекстового поиска.</param>
public record AppOutgoingEventQueryFilterSection(string? FullTextSearchQuery);
