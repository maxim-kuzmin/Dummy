namespace Makc.Dummy.Reader.DomainModel.AppIncomingEvent.Entity.Db.NoSQL;

/// <summary>
/// Настройки базы данных сущности входящего события приложения.
/// </summary>
public abstract record AppIncomingEventEntityDbNoSQLSettings
{
  /// <summary>
  /// Таблица.
  /// </summary>
  public string Collection { get; protected set; } = string.Empty;
}
