namespace Makc.Dummy.Writer.Infrastructure.PostgreSQL.AppOutgoingEventPayload.Entity.Db;

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

    Table = "app_outgoing_event_payload";

    PrimaryKey = $"pk_{Table}";
    
    ColumnForAppOutgoingEventId = "app_outgoing_event_id";
    ColumnForConcurrencyToken = "сoncurrency_token";
    ColumnForData = "data";
    ColumnForId = "id";

    MaxLengthForData = 0;

    ForeignKeyForAppOutgoingEventId = $"fk_{Table}_{tableForAppOutgoingEventPayload}";
  }
}
