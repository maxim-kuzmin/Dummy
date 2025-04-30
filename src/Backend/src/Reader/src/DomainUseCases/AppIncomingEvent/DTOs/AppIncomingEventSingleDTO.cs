namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEvent.DTOs;

/// <summary>
/// Объект передачи данных одиночного входящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="CreatedAt">Дата создания.</param>
/// <param name="Name">Имя.</param>
/// <param name="LoadedAt">Дата загрузки.</param>
/// <param name="ProcessedAt">Дата обработки.</param>
public record AppIncomingEventSingleDTO(
  long Id,
  DateTimeOffset CreatedAt,
  string Name,
  DateTimeOffset? LoadedAt,
  DateTimeOffset? ProcessedAt);
