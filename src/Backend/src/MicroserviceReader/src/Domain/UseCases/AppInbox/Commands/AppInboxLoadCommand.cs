namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppInbox.Commands;

/// <summary>
/// Команда загрузки входящих сообщений приложения.
/// </summary>
/// <param name="EventName">Имя события.</param>
/// <param name="MaxCount">Максимальное количество.</param>
public record AppInboxLoadCommand(string EventName, int MaxCount);
