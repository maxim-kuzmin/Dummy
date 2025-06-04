namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent.Queries;

/// <summary>
/// Запрос списка именованных входящих событий приложения.
/// </summary>
/// <param name="EventName">Имя события.</param>
/// <param name="MaxCount">Максимальное количество.</param>
/// <param name="ObjectIds">Идентификаторы объектов.</param>
public record AppIncomingEventNamedListQuery( string EventName, int MaxCount, List<string>? ObjectIds = null);
