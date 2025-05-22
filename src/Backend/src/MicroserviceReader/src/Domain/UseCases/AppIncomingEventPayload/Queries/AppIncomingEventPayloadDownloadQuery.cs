namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEventPayload.Queries;

/// <summary>
/// Запрос на скачивание полезных нагрузок входящего события.
/// </summary>
/// <param name="EventId">Идентификатор события.</param>
public record AppIncomingEventPayloadDownloadQuery(string EventId);
