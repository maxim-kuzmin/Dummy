namespace Makc.Dummy.Writer.Infrastructure.MSSQLServer.DummyItem.Entity.Db;

/// <summary>
/// Настройки базы данных сущности фиктивного предмета.
/// </summary>
public record DummyItemEntityDbSettings : DummyItemEntityDbSQLSettings
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="schema">Схема.</param>
  public DummyItemEntityDbSettings(string schema)
  {
    Schema = schema;

    Table = "DummyItem";

    PrimaryKey = $"PK_{Table}";

    ColumnForConcurrencyToken = "ConcurrencyToken";
    ColumnForId = "Id";
    ColumnForName = "Name";

    UniqueIndexForName = $"UX_{Table}_Name";
  }
}
