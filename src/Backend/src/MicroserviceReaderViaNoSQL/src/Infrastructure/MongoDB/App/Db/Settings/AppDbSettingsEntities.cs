namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Infrastructure.MongoDB.App.Db.Settings;

/// <summary>
/// Сущности в настройках базы данных приложения.
/// </summary>
public record AppDbSettingsEntities : AppDbNoSQLSettingsEntities
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="schema">Схема.</param>
  public AppDbSettingsEntities()
  {
    AppIncomingEvent = new AppIncomingEventEntityDbSettings();
    AppIncomingEventPayload = new AppIncomingEventPayloadEntityDbSettings();
    DummyItem = new DummyItemEntityDbSettings();
  }
}
