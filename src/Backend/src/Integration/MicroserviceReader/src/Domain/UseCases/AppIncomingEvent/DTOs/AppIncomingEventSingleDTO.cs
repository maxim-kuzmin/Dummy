namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCases.AppIncomingEvent.DTOs;

/// <summary>
/// Объект передачи данных одиночного входящего события приложения.
/// </summary>
public record AppIncomingEventSingleDTO
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
  /// Идентификатор события.
  /// </summary>
  public string EventId { get; set; } = string.Empty;

  /// <summary>
  /// Имя события.
  /// </summary>
  public string EventName { get; set; } = string.Empty;

  /// <summary>
  /// Последняя дата загрузки.
  /// </summary>
  public DateTimeOffset? LastLoadingAt { get; set; }

  /// <summary>
  /// Последняя ошибка загрузки.
  /// </summary>
  public string? LastLoadingError { get; set; }

  /// <summary>
  /// Дата загрузки.
  /// </summary>
  public DateTimeOffset? LoadedAt { get; set; }

  /// <summary>
  /// Количество полезных нагрузок.
  /// </summary>
  public long PayloadCount { get; set; }

  /// <summary>
  /// Общее количество полезных нагрузок.
  /// </summary>
  public long PayloadTotalCount { get; set; }

  /// <summary>
  /// Дата обработки.
  /// </summary>
  public DateTimeOffset? ProcessedAt { get; set; }
}
