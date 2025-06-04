namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent.Actions.Delete;

/// <summary>
/// Запрос действия по удалению входящего события приложения.
/// </summary>
/// <param name="Command">Команда.</param>
public record AppIncomingEventDeleteActionRequest(AppIncomingEventDeleteCommand Command) : ICommand<Result>;
