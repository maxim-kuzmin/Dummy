namespace Makc.Dummy.Shared.Core.App.Event;

/// <summary>
/// Полезная нагрузка события приложения.
/// </summary>
/// <param name="EntityName">Имя сущности.</param>
/// <param name="EntityConcurrencyTokenToDelete">Токен параллелизма сущности для удаления.</param>
/// <param name="EntityConcurrencyTokenToInsert">Токен параллелизма сущности для вставки.</param>
/// <param name="EntityId">Идентификатор сущности.</param>
/// <param name="Data">Данные.</param>
/// <param name="Position">Позиция.</param>
public record AppEventPayload(
  string EntityName,
  string? EntityConcurrencyTokenToDelete,
  string? EntityConcurrencyTokenToInsert,
  string EntityId,
  string? Data,
  int Position);
