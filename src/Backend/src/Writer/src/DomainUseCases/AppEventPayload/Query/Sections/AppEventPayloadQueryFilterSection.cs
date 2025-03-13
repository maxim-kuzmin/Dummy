namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Query.Sections;

/// <summary>
/// Раздел фильтра запроса полезных нагрузок события приложения.
/// </summary>
/// <param name="FullTextSearchQuery">Запрос полнотекстового поиска.</param>
public record AppEventPayloadQueryFilterSection(string? FullTextSearchQuery);
