namespace Makc.Dummy.Writer.Infrastructure.MSSQLServer.AppEventPayload.Entity.Db;

/// <summary>
/// Настройки базы данных сущности полезной нагрузки события приложения.
/// </summary>
public record AppEventPayloadEntityDbSettings : AppEventPayloadEntityDbSQLSettings
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="schema">Схема.</param>
  /// <param name="tableForAppEventPayload">Таблица для полезной нагрузки события приложения.</param>
  public AppEventPayloadEntityDbSettings(string schema, string tableForAppEventPayload)
  {
    Schema = schema;

    Table = "AppEventPayload";

    PrimaryKey = $"PK_{Table}";
    
    ColumnForAppEventId = "AppEventId";
    ColumnForConcurrencyToken = "ConcurrencyToken";
    ColumnForData = "Data";
    ColumnForId = "Id";

    MaxLengthForData = 0;

    ForeignKeyForAppEventId = $"FK_{Table}_{tableForAppEventPayload}";
  }
}
