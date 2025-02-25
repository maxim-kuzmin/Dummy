namespace Makc.Dummy.Reader.DomainUseCases.AppInbox.Actions.Consume;

/// <summary>
/// Команда действия по получению из очереди сообщений о событиях и сохранению их в базе данных как необработанные.
/// </summary>
/// <param name="Sender">Отправитель.</param>
/// <param name="Message">Сообщение.</param>
public record AppInboxConsumeActionCommand(string Sender, string Message) : ICommand<Result>;
