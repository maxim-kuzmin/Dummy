namespace Makc.Dummy.MicroserviceWriter.Infrastructure.PostgreSQL.AppOutgoingEventPayload.Entity.Db;

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
    ColumnForEntityConcurrencyTokenToDelete = "entity_concurrency_token_to_delete";
    ColumnForEntityConcurrencyTokenToInsert = "entity_concurrency_token_to_insert";
    ColumnForEntityId = "entity_id";
    ColumnForEntityName = "entity_name";
    ColumnForId = "id";
    ColumnForPosition = "position";

    ForeignKeyForAppOutgoingEventId = $"fk_{Table}_{tableForAppOutgoingEventPayload}";
  }
}
