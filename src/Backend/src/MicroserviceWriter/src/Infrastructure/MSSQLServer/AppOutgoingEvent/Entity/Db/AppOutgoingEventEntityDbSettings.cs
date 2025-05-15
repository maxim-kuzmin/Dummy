namespace Makc.Dummy.MicroserviceWriter.Infrastructure.MSSQLServer.AppOutgoingEvent.Entity.Db;

/// <summary>
/// Настройки базы данных сущности исходящего события приложения.
/// </summary>
public record AppOutgoingEventEntityDbSettings : AppOutgoingEventEntityDbSQLSettings
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="schema">Схема.</param>
  public AppOutgoingEventEntityDbSettings(string schema)
  {
    Schema = schema;

    Table = "AppOutgoingEvent";

    PrimaryKey = $"PK_{Table}";

    ColumnForConcurrencyToken = "ConcurrencyToken";
    ColumnForCreatedAt = "CreatedAt";
    ColumnForId = "Id";    
    ColumnForName = "Name";
    ColumnForPublishedAt = "PublishedAt";
  }
}
