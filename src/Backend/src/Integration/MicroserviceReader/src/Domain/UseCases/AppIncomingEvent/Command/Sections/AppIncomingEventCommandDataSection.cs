namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCases.AppIncomingEvent.Command.Sections;

/// <summary>
/// Раздел данных команды входящего события приложения.
/// </summary>
/// <param name="EventId">Идентификатор события.</param>
/// <param name="EventName">Имя события.</param>
/// <param name="LastLoadingAt">Последняя дата загрузки.</param>
/// <param name="LastLoadingError">Последняя ошибка загрузки.</param>
/// <param name="LoadedAt">Дата загрузки.</param>
/// <param name="PayloadCount">Количество полезной нагрузки.</param>
/// <param name="PayloadTotalCount">Общее количество полезной нагрузки.</param>
/// <param name="ProcessedAt">Дата обработки.</param>
public record AppIncomingEventCommandDataSection(
  string EventId,
  string EventName,
  DateTimeOffset? LastLoadingAt,
  string? LastLoadingError,
  DateTimeOffset? LoadedAt,
  int PayloadCount,
  int PayloadTotalCount,
  DateTimeOffset? ProcessedAt);
