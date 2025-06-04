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
  public string? EntityConcurrencyTokenToDelete { get; set; }

  /// <summary>
  /// Токен параллелизма сущности для вставки.
  /// </summary>
  public string? EntityConcurrencyTokenToInsert { get; set; }

  /// <summary>
  /// Позиция.
  /// </summary>
  public int Position { get; set; }

  /// <summary>
  /// Получить действие события.
  /// </summary>
  /// <returns>Действие события.</returns>
  public AppEventActionEnum GetEventAction()
  {
    bool isUnknownAction = string.IsNullOrWhiteSpace(EntityConcurrencyTokenToDelete)
      &&
      string.IsNullOrWhiteSpace(EntityConcurrencyTokenToInsert);

    if (isUnknownAction)
    {
      return AppEventActionEnum.Unknown;
    }

    if (string.IsNullOrWhiteSpace(EntityConcurrencyTokenToDelete))
    {
      return AppEventActionEnum.Insert;
    }
    else if (string.IsNullOrWhiteSpace(EntityConcurrencyTokenToInsert))
    {
      return AppEventActionEnum.Delete;
    }
    else
    {
      return AppEventActionEnum.Update;
    }
  }
}
