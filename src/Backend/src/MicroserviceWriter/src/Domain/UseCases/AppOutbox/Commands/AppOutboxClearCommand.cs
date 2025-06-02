namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutbox.Commands;

/// <summary>
/// Команда выдачи исходящего сообщения приложения.
/// </summary>
/// <param name="PublishedEventsLifetimeInMinutes">Время жизни опубликованных сообщений в минутах.</param>
public record AppOutboxClearCommand(int PublishedEventsLifetimeInMinutes) : ICommand<Result>;
