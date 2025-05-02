namespace Makc.Dummy.Shared.Core.App.Event;

/// <summary>
/// Полезная нагрузка события приложения.
/// </summary>
public record AppEventPayload
{
  /// <summary>
  /// Идентификатор сущности.
  /// </summary>
  public string EntityId { get; set; } = string.Empty;

  /// <summary>
  /// Имя сущности.
  /// </summary>
  public string EntityName { get; set; } = string.Empty;

  /// <summary>
  /// Токен параллелизма сущности для удаления.
  /// </summary>
  public string? EntityConcurrencyTokenToDelete { get; set; } = string.Empty;

  /// <summary>
  /// Токен параллелизма сущности для вставки.
  /// </summary>
  public string? EntityConcurrencyTokenToInsert { get; set; }

  /// <summary>
  /// Позиция.
  /// </summary>
  public int Position { get; set; }
}
