namespace Makc.Dummy.Writer.Infrastructure.MSSQLServer.App.Db.Settings;

/// <summary>
/// Сущности в настройках базы данных приложения.
/// </summary>
public record AppDbSettingsEntities : AppDbSQLSettingsEntities
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="schema">Схема.</param>
  public AppDbSettingsEntities(string schema)
  {
    AppOutgoingEvent = new AppOutgoingEventEntityDbSettings(schema);
    AppOutgoingEventPayload = new AppOutgoingEventPayloadEntityDbSettings(schema, AppOutgoingEvent.Table);
    DummyItem = new DummyItemEntityDbSettings(schema);
  }
}
