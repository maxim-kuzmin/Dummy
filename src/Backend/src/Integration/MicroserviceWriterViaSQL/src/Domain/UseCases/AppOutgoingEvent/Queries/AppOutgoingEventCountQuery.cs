namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEvent.Queries;

/// <summary>
/// Запрос количества исходящих событий приложения.
/// </summary>
/// <param name="Filter">Фильтр.</param>
public record AppOutgoingEventCountQuery(
  AppOutgoingEventQueryFilterSection? Filter);
