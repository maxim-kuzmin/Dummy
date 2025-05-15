namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppInbox.Actions.Consume;

/// <summary>
/// Команда действия по потреблению входящих сообщений приложения.
/// </summary>
/// <param name="Sender">Отправитель.</param>
/// <param name="Message">Сообщение.</param>
public record AppInboxConsumeActionCommand(string Sender, string Message) : ICommand<Result>;
