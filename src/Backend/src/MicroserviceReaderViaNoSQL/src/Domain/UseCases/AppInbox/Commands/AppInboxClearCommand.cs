namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppInbox.Commands;

/// <summary>
/// Команда выдачи исходящего сообщения приложения.
/// </summary>
/// <param name="EventMaxCountToClear">Максимальное количество событий для очистки.</param>
/// <param name="ProcessedEventsLifetimeInMinutes">Время жизни обработанных сообщений в минутах.</param>
/// <param name="TimeoutInMillisecondsToGetEvents">Таймаут в миллисекундах для получения событий.</param>
public record AppInboxClearCommand(
  int EventMaxCountToClear,
  int ProcessedEventsLifetimeInMinutes,
  int TimeoutInMillisecondsToGetEvents) : ICommand<Result>;
