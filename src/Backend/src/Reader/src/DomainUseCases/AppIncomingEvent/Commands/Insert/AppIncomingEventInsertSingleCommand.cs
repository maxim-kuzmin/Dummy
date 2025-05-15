namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEvent.Commands.Insert;

/// <summary>
/// Команда вставки единственного входящего события приложения.
/// </summary>
/// <param name="EventId">Идентификатор события.</param>
/// <param name="EventName">Имя события.</param>
/// <param name="LastLoadingAt">Последняя дата загрузки.</param>
/// <param name="LastLoadingError">Последняя ошибка загрузки.</param>
/// <param name="LoadedAt">Дата загрузки.</param>
/// <param name="PayloadCount">Количество полезной нагрузки.</param>
/// <param name="PayloadTotalCount">Общее количество полезной нагрузки.</param>
/// <param name="ProcessedAt">Дата обработки.</param>
public record AppIncomingEventInsertSingleCommand(
  string EventId,
  string EventName,
  DateTimeOffset? LastLoadingAt,
  string? LastLoadingError,
  DateTimeOffset? LoadedAt,
  int PayloadCount,
  int PayloadTotalCount,
  DateTimeOffset? ProcessedAt);
