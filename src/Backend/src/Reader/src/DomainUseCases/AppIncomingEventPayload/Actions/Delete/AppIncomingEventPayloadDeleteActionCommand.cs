namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEventPayload.Actions.Delete;

/// <summary>
/// Команда действия по удалению полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record AppIncomingEventPayloadDeleteActionCommand(long Id) : ICommand<Result>;
