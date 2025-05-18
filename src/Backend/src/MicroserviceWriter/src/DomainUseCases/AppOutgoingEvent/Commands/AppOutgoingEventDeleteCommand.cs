namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEvent.Commands;

/// <summary>
/// Команда удаления исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record AppOutgoingEventDeleteCommand(long Id);
