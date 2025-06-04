namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.Model.DummyItem.Entity.Db.SQL;

/// <summary>
/// Настройки базы данных SQL сущности фиктивного предмета.
/// </summary>
public abstract record DummyItemEntityDbSQLSettings : DummyItemEntitySettings
{
  /// <summary>
  /// Столбец для токена параллелизма.
  /// </summary>
  public string ColumnForConcurrencyToken { get; protected set; } = string.Empty;

  /// <summary>
  /// Столбец для идентификатора.
  /// </summary>
  public string ColumnForId { get; protected set; } = string.Empty;

  /// <summary>
  /// Столбец для имени.
  /// </summary>
  public string ColumnForName { get; protected set; } = string.Empty;

  /// <summary>
  /// Первичный ключ.
  /// </summary>
  public string PrimaryKey { get; protected set; } = string.Empty;

  /// <summary>
  /// Схема.
  /// </summary>
  public string Schema { get; protected set; } = string.Empty;

  /// <summary>
  /// Таблица.
  /// </summary>
  public string Table { get; protected set; } = string.Empty;
  
  /// <summary>
  /// Уникальный индекс для имени.
  /// </summary>
  public string UniqueIndexForName { get; protected set; } = string.Empty;
}
