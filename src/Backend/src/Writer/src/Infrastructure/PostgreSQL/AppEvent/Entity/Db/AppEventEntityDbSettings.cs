namespace Makc.Dummy.Writer.Infrastructure.PostgreSQL.AppEvent.Entity.Db;

/// <summary>
/// Настройки базы данных сущности события приложения.
/// </summary>
public record AppEventEntityDbSettings : AppEventEntityDbSettingsBase
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="schema">Схема.</param>
  public AppEventEntityDbSettings(string schema)
  {
    Schema = schema;

    Table = "app_event";

    PrimaryKey = $"pk_{Table}";

    ColumnForConcurrencyToken = "сoncurrency_token";
    ColumnForCreatedAt = "created_at";
    ColumnForId = "id";
    ColumnForIsPublished = "is_published";
    ColumnForName = "name";

    MaxLengthForName = 255;
  }
}
