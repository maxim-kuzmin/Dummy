namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEventPayload.Actions.Delete;

/// <summary>
/// Команда действия по удалению полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record AppIncomingEventPayloadDeleteActionCommand(string ObjectId) : ICommand<Result>;
