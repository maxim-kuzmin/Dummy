namespace Makc.Dummy.Writer.Infrastructure.MSSQLServer.AppEvent.Entity.Db;

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

    Table = "AppEvent";

    PrimaryKey = $"PK_{Table}";

    ColumnForConcurrencyToken = "ConcurrencyToken";
    ColumnForCreatedAt = "CreatedAt";
    ColumnForId = "Id";
    ColumnForIsPublished = "IsPublished";
    ColumnForName = "Name";

    MaxLengthForName = 255;
  }
}
