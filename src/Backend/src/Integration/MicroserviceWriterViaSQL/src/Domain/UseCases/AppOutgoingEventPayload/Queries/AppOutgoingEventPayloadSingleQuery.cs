namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEventPayload.Queries;

/// <summary>
/// Запрос единственного полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record AppOutgoingEventPayloadSingleQuery(long Id);
