namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppInbox.Commands;

/// <summary>
/// Команда выдачи исходящего сообщения приложения.
/// </summary>
/// <param name="ProcessedEventsLifetimeInMinutes">Время жизни обработанных сообщений в минутах.</param>
public record AppInboxClearCommand(int ProcessedEventsLifetimeInMinutes) : ICommand<Result>;
