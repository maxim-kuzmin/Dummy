namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEventPayload.DTOs;

/// <summary>
/// Объект передачи данных полезной нагрузки исходящего события приложения.
/// </summary>
public record AppOutgoingEventPayloadSingleDTO
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

  /// <summary>
  /// Токен параллелизма для удаления.
  /// </summary>
  public string? EntityConcurrencyTokenToDelete { get; set; }

  /// <summary>
  /// Токен параллелизма для вставки.
  /// </summary>
  public string? EntityConcurrencyTokenToInsert { get; set; }

  /// <summary>
  /// Идентификатор сущности.
  /// </summary>
  public string EntityId { get; set; } = string.Empty;

  /// <summary>
  /// Имя сущности.
  /// </summary>
  public string EntityName { get; set; } = string.Empty;

  /// <summary>
  /// Позиция.
  /// </summary>
  public int Position { get; set; }
}
