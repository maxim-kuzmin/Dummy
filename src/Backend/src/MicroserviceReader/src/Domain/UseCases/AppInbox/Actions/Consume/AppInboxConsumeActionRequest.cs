namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppInbox.Actions.Consume;

/// <summary>
/// Команда действия по потреблению входящих сообщений приложения.
/// </summary>
/// <param name="Command">Команда.</param>
public record AppInboxConsumeActionRequest(AppInboxConsumeCommand Command) : ICommand<Result>;
