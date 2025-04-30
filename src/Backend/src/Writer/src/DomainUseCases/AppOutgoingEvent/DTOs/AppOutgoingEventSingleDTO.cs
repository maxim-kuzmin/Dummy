namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.DTOs;

/// <summary>
/// Объект передачи данных одиночного исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="CreatedAt">Дата создания.</param>
/// <param name="Name">Имя.</param>
/// <param name="PublishedAt">Дата публикации.</param>
public record AppOutgoingEventSingleDTO(
  long Id,
  DateTimeOffset CreatedAt,
  string Name,
  DateTimeOffset? PublishedAt);
