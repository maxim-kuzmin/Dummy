namespace Makc.Dummy.Writer.Infrastructure.PostgreSQL.AppOutgoingEvent.Entity.Db;

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

    Table = "app_outgoing_event";

    PrimaryKey = $"pk_{Table}";

    ColumnForConcurrencyToken = "сoncurrency_token";
    ColumnForCreatedAt = "created_at";
    ColumnForId = "id";    
    ColumnForName = "name";
    ColumnForPublishedAt = "published_at";

    MaxLengthForConcurrencyToken = 255;
    MaxLengthForName = 255;
  }
}
