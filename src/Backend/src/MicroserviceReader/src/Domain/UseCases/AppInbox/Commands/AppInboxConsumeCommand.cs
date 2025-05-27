namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppInbox.Commands;

/// <summary>
/// Команда потребления входящих сообщений приложения.
/// </summary>
/// <param name="Sender">Отправитель.</param>
/// <param name="Message">Сообщение.</param>
public record AppInboxConsumeCommand(string Sender, string Message);
