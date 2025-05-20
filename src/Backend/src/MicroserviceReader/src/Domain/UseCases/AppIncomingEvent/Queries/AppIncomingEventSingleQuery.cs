namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEvent.Queries;

/// <summary>
/// Запрос единственного входящего события приложения.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record AppIncomingEventSingleQuery(string? ObjectId);
