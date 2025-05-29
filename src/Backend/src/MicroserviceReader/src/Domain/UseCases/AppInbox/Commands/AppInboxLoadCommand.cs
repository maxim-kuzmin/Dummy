namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppInbox.Commands;

/// <summary>
/// Команда загрузки входящих сообщений приложения.
/// </summary>
/// <param name="EventName">Имя события.</param>
/// <param name="EventMaxCountToLoad">Максимальное количество событий для загрузки.</param>
/// <param name="PayloadPageSize">Размер страницы полезных нагрузок.</param>
/// <param name="TimeoutInMillisecondsToGetPayloads">Таймаут в миллисекундах для получения полезных нагрузок.</param>
public record AppInboxLoadCommand(
  string EventName,
  int EventMaxCountToLoad,
  int PayloadPageSize,
  int TimeoutInMillisecondsToGetPayloads
);
