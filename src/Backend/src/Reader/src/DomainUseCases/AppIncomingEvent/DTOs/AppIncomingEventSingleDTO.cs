namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEvent.DTOs;

/// <summary>
/// Объект передачи данных одиночного входящего события приложения.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
/// <param name="CreatedAt">Дата создания.</param>
/// <param name="EventId">Идентификатор события.</param>
/// <param name="EventName">Имя события.</param>
/// <param name="LoadedAt">Дата загрузки.</param>
/// <param name="ProcessedAt">Дата обработки.</param>
public record AppIncomingEventSingleDTO(
  string? ObjectId,
  DateTimeOffset CreatedAt,
  string EventId,
  string EventName,
  DateTimeOffset? LoadedAt,
  DateTimeOffset? ProcessedAt);
