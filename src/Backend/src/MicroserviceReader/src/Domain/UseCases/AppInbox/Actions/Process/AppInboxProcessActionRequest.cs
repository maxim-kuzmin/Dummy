namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppInbox.Actions.Process;

/// <summary>
/// Запрос действия по обработке входящих сообщений приложения.
/// </summary>
/// <param name="Command">Команда.</param>
public record AppInboxProcessActionRequest(AppInboxProcessCommand Command) : ICommand<Result>;
