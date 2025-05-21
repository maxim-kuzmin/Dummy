namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent.Commands;

/// <summary>
/// Команда удаления исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record AppOutgoingEventDeleteCommand(long Id);
