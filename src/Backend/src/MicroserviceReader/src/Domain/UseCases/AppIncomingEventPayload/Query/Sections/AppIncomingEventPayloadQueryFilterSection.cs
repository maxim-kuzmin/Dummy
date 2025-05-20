namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEventPayload.Query.Sections;

/// <summary>
/// Раздел фильтра запроса полезных нагрузок входящего события приложения.
/// </summary>
/// <param name="FullTextSearchQuery">Запрос полнотекстового поиска.</param>
public record AppIncomingEventPayloadQueryFilterSection(string? FullTextSearchQuery);
