namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Infrastructure.MongoDB.AppIncomingEventPayload.Entity.Db;

/// <summary>
/// Настройки базы данных сущности полезной нагрузки входящего события приложения.
/// </summary>
public record AppIncomingEventPayloadEntityDbSettings : AppIncomingEventPayloadEntityDbNoSQLSettings
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  public AppIncomingEventPayloadEntityDbSettings()
  {
    Collection = "AppIncomingEventPayload";
  }
}
