namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEvent.Commands;

/// <summary>
/// Команда удаления входящего события приложения.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record AppIncomingEventDeleteCommand(string ObjectId);
