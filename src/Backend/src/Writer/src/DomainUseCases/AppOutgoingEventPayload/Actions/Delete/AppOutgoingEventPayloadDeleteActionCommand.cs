namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEventPayload.Actions.Delete;

/// <summary>
/// Команда действия по удалению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record AppOutgoingEventPayloadDeleteActionCommand(long Id) : ICommand<Result>;
