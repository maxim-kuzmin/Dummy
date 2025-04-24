namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEventPayload.Query.Sections;

/// <summary>
/// Раздел фильтра запроса полезных нагрузок исходящего события приложения.
/// </summary>
/// <param name="FullTextSearchQuery">Запрос полнотекстового поиска.</param>
public record AppOutgoingEventPayloadQueryFilterSection(string? FullTextSearchQuery);
