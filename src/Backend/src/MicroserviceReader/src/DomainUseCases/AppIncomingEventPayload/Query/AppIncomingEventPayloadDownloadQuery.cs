namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEventPayload.Query;

/// <summary>
/// Запрос на скачивание полезных нагрузок входящего события.
/// </summary>
/// <param name="EventId">Идентификатор события.</param>
public record AppIncomingEventPayloadDownloadQuery(string EventId)
{
}
