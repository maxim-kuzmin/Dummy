namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEvent.Queries;

/// <summary>
/// Запрос количества входящих событий приложения.
/// </summary>
/// <param name="Filter">Фильтр.</param>
public record AppIncomingEventCountQuery(
  AppIncomingEventQueryFilterSection? Filter);
