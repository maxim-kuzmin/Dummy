namespace Makc.Dummy.Reader.DomainUseCases.AppInbox.Actions.Load;

/// <summary>
/// Команда действия по загрузке входящих сообщений приложения.
/// </summary>
/// <param name="EventName">Имя события.</param>
/// <param name="MaxCount">Максимальное количество.</param>
public record AppInboxLoadActionCommand(string EventName, int MaxCount) : ICommand<Result>;
