namespace Makc.Dummy.Writer.Infrastructure.PostgreSQL.App.Db.Settings;

/// <summary>
/// Сущности в настройках базы данных приложения.
/// </summary>
public record AppDbSettingsEntities : AppDbSettingsEntitiesBase
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="schema">Схема.</param>
  public AppDbSettingsEntities(string schema)
  {
    AppEvent = new AppEventEntityDbSettings(schema);
    AppEventPayload = new AppEventPayloadEntityDbSettings(schema, AppEvent.Table);
    DummyItem = new DummyItemEntityDbSettings(schema);
  }
}
