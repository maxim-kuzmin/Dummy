namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppInbox.Actions.Load;

/// <summary>
/// Запрос действия по загрузке входящих сообщений приложения.
/// </summary>
/// <param name="Command">Команда.</param>
public record AppInboxLoadActionRequest(AppInboxLoadCommand Command) : ICommand<Result>;
