namespace Makc.Dummy.Reader.Infrastructure.MongoDB.AppIncomingEvent.Entity.Db;

/// <summary>
/// Настройки базы данных сущности входящего события приложения.
/// </summary>
public record AppIncomingEventEntityDbSettings : AppIncomingEventEntityDbNoSQLSettings
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  public AppIncomingEventEntityDbSettings()
  {
    Collection = "AppIncomingEvent";
  }
}
