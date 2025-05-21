namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent.DTOs;

/// <summary>
/// Объект передачи данных одиночного исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="ConcurrencyToken">Токен параллелизма.</param>
/// <param name="CreatedAt">Дата создания.</param>
/// <param name="Name">Имя.</param>
/// <param name="PublishedAt">Дата публикации.</param>
public record AppOutgoingEventSingleDTO(
  long Id,
  string ConcurrencyToken,
  DateTimeOffset CreatedAt,
  string Name,
  DateTimeOffset? PublishedAt);
