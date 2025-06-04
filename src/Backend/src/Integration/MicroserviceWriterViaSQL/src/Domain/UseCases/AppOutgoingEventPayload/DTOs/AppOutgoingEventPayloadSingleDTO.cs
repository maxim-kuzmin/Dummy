namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEventPayload.DTOs;

/// <summary>
/// Объект передачи данных полезной нагрузки исходящего события приложения.
/// </summary>
public record AppOutgoingEventPayloadSingleDTO : AppEventPayload
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
  /// Идентификатор исходящего события приложения.
  /// </summary>
  public long AppOutgoingEventId { get; set; }

  /// <summary>
  /// Данные.
  /// </summary>
  public string? Data { get; set; }
}
