namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEvent.DTOs;

/// <summary>
/// Объект передачи данных одиночного входящего события приложения.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
/// <param name="ConcurrencyToken">Токен паралеллизма.</param>
/// <param name="CreatedAt">Дата создания.</param>
/// <param name="EventId">Идентификатор события.</param>
/// <param name="EventName">Имя события.</param>
/// <param name="LastLoadingAt">Последняя дата загрузки.</param>
/// <param name="LastLoadingError">Последняя ошибка загрузки.</param>
/// <param name="LoadedAt">Дата загрузки.</param>
/// <param name="PayloadCount">Количество полезных нагрузок.</param>
/// <param name="PayloadTotalCount">Общее количество полезных нагрузок.</param>
/// <param name="ProcessedAt">Дата обработки.</param>
public record AppIncomingEventSingleDTO(
  string? ObjectId,
  string ConcurrencyToken,
  DateTimeOffset CreatedAt,
  string EventId,
  string EventName,
  DateTimeOffset? LastLoadingAt,
  string? LastLoadingError,
  DateTimeOffset? LoadedAt,
  int PayloadCount,
  int PayloadTotalCount,
  DateTimeOffset? ProcessedAt);
