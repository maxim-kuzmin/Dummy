namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEvent.Queries;

/// <summary>
/// Запрос списка обработанных.
/// </summary>
/// <param name="MaxDate">Максимальная дата.</param>
public record AppIncomingEventProcessedListQuery(DateTimeOffset? MaxDate);
