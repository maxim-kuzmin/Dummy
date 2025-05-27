namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppInbox.Actions.Load;

/// <summary>
/// Запрос действия по загрузке входящих сообщений приложения.
/// </summary>
/// <param name="Command">Команда.</param>
public record AppInboxLoadActionRequest(AppInboxLoadCommand Command) : ICommand<Result>;
