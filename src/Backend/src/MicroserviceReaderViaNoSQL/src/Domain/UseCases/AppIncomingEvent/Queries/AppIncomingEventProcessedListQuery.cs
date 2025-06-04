namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent.Queries;

/// <summary>
/// Запрос списка обработанных.
/// </summary>
/// <param name="MaxCount">Максимальное количество.</param>
/// <param name="MaxDate">Максимальная дата.</param>
public record AppIncomingEventProcessedListQuery(int MaxCount, DateTimeOffset? MaxDate);
