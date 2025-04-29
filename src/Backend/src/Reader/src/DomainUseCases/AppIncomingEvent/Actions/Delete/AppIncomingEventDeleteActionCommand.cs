namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEvent.Actions.Delete;

/// <summary>
/// Команда действия по удалению входящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record AppIncomingEventDeleteActionCommand(long Id) : ICommand<Result>;
