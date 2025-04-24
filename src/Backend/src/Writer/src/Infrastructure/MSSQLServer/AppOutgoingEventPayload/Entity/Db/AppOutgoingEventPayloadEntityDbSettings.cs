namespace Makc.Dummy.Writer.Infrastructure.MSSQLServer.AppOutgoingEventPayload.Entity.Db;

/// <summary>
/// Настройки базы данных сущности полезной нагрузки исходящего события приложения.
/// </summary>
public record AppOutgoingEventPayloadEntityDbSettings : AppOutgoingEventPayloadEntityDbSQLSettings
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="schema">Схема.</param>
  /// <param name="tableForAppOutgoingEventPayload">Таблица для полезной нагрузки исходящего события приложения.</param>
  public AppOutgoingEventPayloadEntityDbSettings(string schema, string tableForAppOutgoingEventPayload)
  {
    Schema = schema;

    Table = "AppOutgoingEventPayload";

    PrimaryKey = $"PK_{Table}";
    
    ColumnForAppOutgoingEventId = "AppOutgoingEventId";
    ColumnForConcurrencyToken = "ConcurrencyToken";
    ColumnForData = "Data";
    ColumnForId = "Id";

    MaxLengthForData = 0;

    ForeignKeyForAppOutgoingEventId = $"FK_{Table}_{tableForAppOutgoingEventPayload}";
  }
}
