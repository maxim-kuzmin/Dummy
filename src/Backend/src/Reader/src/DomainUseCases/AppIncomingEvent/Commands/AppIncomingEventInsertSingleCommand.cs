namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEvent.Commands;

/// <summary>
/// Команда вставки единственного входящего события приложения.
/// </summary>
/// <param name="EventId">Идентификатор события.</param>
/// <param name="EventName">Имя события.</param>
public record AppIncomingEventInsertSingleCommand(string EventId, string EventName);
