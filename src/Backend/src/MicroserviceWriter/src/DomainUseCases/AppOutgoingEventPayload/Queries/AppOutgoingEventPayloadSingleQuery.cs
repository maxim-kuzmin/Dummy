namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEventPayload.Queries;

/// <summary>
/// Запрос единственной полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record AppOutgoingEventPayloadSingleQuery(long Id);
