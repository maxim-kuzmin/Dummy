namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEvent.Actions.Delete;

/// <summary>
/// Команда действия по удалению входящего события приложения.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
public record AppIncomingEventDeleteActionCommand(string ObjectId) : ICommand<Result>;
