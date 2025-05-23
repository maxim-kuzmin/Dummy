namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent.DTOs;

/// <summary>
/// Объект передачи данных одиночного исходящего события приложения.
/// </summary>
public record AppOutgoingEventSingleDTO
{
  /// <summary>
  /// Идентификатор.
  /// </summary>
  public long Id { get; set; }

  /// <summary>
  /// Токен параллелизма.
  /// </summary>
  public string ConcurrencyToken { get; set; } = string.Empty;

  /// <summary>
  /// Дата создания.
  /// </summary>
  public DateTimeOffset CreatedAt { get; set; }

  /// <summary>
  /// Имя.
  /// </summary>
  public string Name { get; set; } = string.Empty;

  /// <summary>
  /// Дата публикации.
  /// </summary>
  public DateTimeOffset? PublishedAt { get; set; }
}
