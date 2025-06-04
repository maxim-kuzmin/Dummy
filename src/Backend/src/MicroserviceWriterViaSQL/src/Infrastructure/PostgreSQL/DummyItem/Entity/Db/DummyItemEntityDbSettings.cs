namespace Makc.Dummy.MicroserviceWriterViaSQL.Infrastructure.PostgreSQL.DummyItem.Entity.Db;

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

    Table = "dummy_item";

    PrimaryKey = $"pk_{Table}";

    ColumnForConcurrencyToken = "сoncurrency_token";
    ColumnForId = "id";
    ColumnForName = "name";

    UniqueIndexForName = $"ux_{Table}_name";
  }
}
