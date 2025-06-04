namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEventPayload.DTOs;

/// <summary>
/// Объект передачи данных полезной нагрузки входящего события приложения.
/// </summary>
public record AppIncomingEventPayloadSingleDTO : AppEventPayload
{
  /// <summary>
  /// Идентификатор объекта.
  /// </summary>
  public string? ObjectId { get; set; }

  /// <summary>
  /// Токен паралеллизма.
  /// </summary>
  public string ConcurrencyToken { get; set; } = string.Empty;

  /// <summary>
  /// Дата создания.
  /// </summary>
  public DateTimeOffset CreatedAt { get; set; }

  /// <summary>
  /// Идентификатор объекта входящего события приложения.
  /// </summary>
  public string AppIncomingEventObjectId { get; set; } = string.Empty;

  /// <summary>
  /// Данные.
  /// </summary>
  public string? Data { get; set; }

  /// <summary>
  /// Идентификатор полезной нагрузки события.
  /// </summary>
  public string EventPayloadId { get; set; } = string.Empty;
}
