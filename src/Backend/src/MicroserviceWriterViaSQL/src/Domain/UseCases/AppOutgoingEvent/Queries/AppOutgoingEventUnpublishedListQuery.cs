namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEvent.Queries;

/// <summary>
/// Запрос списка неопубликованных исходящих событий приложения.
/// </summary>
/// <param name="Ids">Идентификаторы.</param>
/// <param name="MaxCount">Максимальное количество.</param>
public record AppOutgoingEventUnpublishedListQuery(List<long>? Ids, int MaxCount);
