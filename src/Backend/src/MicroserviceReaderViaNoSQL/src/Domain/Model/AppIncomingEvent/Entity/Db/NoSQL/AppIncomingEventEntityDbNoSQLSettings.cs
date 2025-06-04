namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.Model.AppIncomingEvent.Entity.Db.NoSQL;

/// <summary>
/// Настройки базы данных сущности входящего события приложения.
/// </summary>
public abstract record AppIncomingEventEntityDbNoSQLSettings : AppIncomingEventEntitySettings
{
  /// <summary>
  /// Таблица.
  /// </summary>
  public string Collection { get; protected set; } = string.Empty;
}
