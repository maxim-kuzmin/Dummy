namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.AppOutgoingEventPayload.Query.Sections;

/// <summary>
/// Раздел фильтра запроса полезных нагрузок исходящего события приложения.
/// </summary>
/// <param name="FullTextSearchQuery">Запрос полнотекстового поиска.</param>
/// <param name="AppOutgoingEventId">Идентификатор исходящего события приложения.</param>
public record AppOutgoingEventPayloadQueryFilterSection(
  string? FullTextSearchQuery,
  long AppOutgoingEventId);
