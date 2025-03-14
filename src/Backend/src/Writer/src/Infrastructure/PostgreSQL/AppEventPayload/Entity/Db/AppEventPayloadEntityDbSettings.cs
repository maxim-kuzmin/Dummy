namespace Makc.Dummy.Writer.Infrastructure.PostgreSQL.AppEventPayload.Entity.Db;

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

    Table = "app_event_payload";

    PrimaryKey = $"pk_{Table}";
    
    ColumnForAppEventId = "app_event_id";
    ColumnForConcurrencyToken = "сoncurrency_token";
    ColumnForData = "data";
    ColumnForId = "id";

    MaxLengthForData = 0;

    ForeignKeyForAppEventId = $"fk_{Table}_{tableForAppEventPayload}";
  }
}
