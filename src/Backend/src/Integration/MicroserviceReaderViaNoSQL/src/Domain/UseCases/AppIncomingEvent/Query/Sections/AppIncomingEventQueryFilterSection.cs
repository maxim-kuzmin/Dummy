namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent.Query.Sections;

/// <summary>
/// Раздел фильтра запроса входящих событий приложения.
/// </summary>
/// <param name="FullTextSearchQuery">Запрос полнотекстового поиска.</param>
public record AppIncomingEventQueryFilterSection(string? FullTextSearchQuery);
