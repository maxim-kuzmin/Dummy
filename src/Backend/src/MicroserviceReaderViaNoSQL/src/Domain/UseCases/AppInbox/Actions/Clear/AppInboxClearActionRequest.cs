namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppInbox.Actions.Clear;

/// <summary>
/// Запрос действия по очистке входящих сообщений приложения
/// </summary>
/// <param name="Command">Команда.</param>
public record AppInboxClearActionRequest(AppInboxClearCommand Command) : ICommand<Result>;
