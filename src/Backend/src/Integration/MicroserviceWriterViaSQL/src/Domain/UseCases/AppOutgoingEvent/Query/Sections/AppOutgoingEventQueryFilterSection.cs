﻿namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEvent.Query.Sections;

/// <summary>
/// Раздел фильтра запроса исходящих событий приложения.
/// </summary>
/// <param name="FullTextSearchQuery">Запрос полнотекстового поиска.</param>
public record AppOutgoingEventQueryFilterSection(
  string? FullTextSearchQuery);
