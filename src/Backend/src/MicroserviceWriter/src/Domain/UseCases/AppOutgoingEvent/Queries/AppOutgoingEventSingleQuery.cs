namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent.Queries;

/// <summary>
/// Запрос единственного исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record AppOutgoingEventSingleQuery(long Id);
