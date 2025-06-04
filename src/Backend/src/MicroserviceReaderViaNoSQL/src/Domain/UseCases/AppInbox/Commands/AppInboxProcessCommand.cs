namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppInbox.Commands;

/// <summary>
/// Команда обработки входящих сообщений приложения.
/// </summary>
/// <param name="EventName">Имя события.</param>
/// <param name="EventMaxCountToProcess">Максимальное количество событий для обработки.</param>
public record AppInboxProcessCommand(string EventName, int EventMaxCountToProcess);
