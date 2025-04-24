namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.Actions.Delete;

/// <summary>
/// Команда действия по удалению исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record AppOutgoingEventDeleteActionCommand(long Id) : ICommand<Result>;
