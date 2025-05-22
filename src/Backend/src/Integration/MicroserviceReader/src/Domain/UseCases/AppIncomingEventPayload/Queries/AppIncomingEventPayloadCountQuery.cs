namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCases.AppIncomingEventPayload.Queries;

/// <summary>
/// Запрос количества полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="Filter">Фильтр.</param>
public record AppIncomingEventPayloadCountQuery(
  AppIncomingEventPayloadQueryFilterSection? Filter);
