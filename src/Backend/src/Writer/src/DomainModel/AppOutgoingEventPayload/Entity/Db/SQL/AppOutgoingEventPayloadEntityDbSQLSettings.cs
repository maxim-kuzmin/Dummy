namespace Makc.Dummy.Writer.DomainModel.AppOutgoingEventPayload.Entity.Db.SQL;

/// <summary>
/// Настройки базы данных SQL сущности полезной нагрузки исходящего события приложения.
/// </summary>
public abstract record AppOutgoingEventPayloadEntityDbSQLSettings : AppOutgoingEventPayloadEntitySettings
{
  /// <summary>
  /// Столбец для токена параллелизма.
  /// </summary>
  public string ColumnForConcurrencyToken { get; protected set; } = string.Empty;

  /// <summary>
  /// Внешний ключ для идентификатора исходящего события приложения.
  /// </summary>
  public string ColumnForAppOutgoingEventId { get; protected set; } = string.Empty;

  /// <summary>
  /// Столбец для данных.
  /// </summary>
  public string ColumnForData { get; protected set; } = string.Empty;

  /// <summary>
  /// Столбец для токена параллелизма сущности для удаления.
  /// </summary>
  public string ColumnForEntityConcurrencyTokenToDelete { get; protected set; } = string.Empty;

  /// <summary>
  /// Столбец для токена параллелизма сущности для вставки.
  /// </summary>
  public string ColumnForEntityConcurrencyTokenToInsert { get; protected set; } = string.Empty;

  /// <summary>
  /// Столбец для идентификатора сущности.
  /// </summary>
  public string ColumnForEntityId { get; protected set; } = string.Empty;

  /// <summary>
  /// Столбец для имени сущности.
  /// </summary>
  public string ColumnForEntityName { get; protected set; } = string.Empty;

  /// <summary>
  /// Столбец для позиции.
  /// </summary>
  public string ColumnForPosition { get; protected set; } = string.Empty;

  /// <summary>
  /// Столбец для идентификатора.
  /// </summary>
  public string ColumnForId { get; protected set; } = string.Empty;

  /// <summary>
  /// Внешний ключ для идентификатора исходящего события приложения.
  /// </summary>
  public string ForeignKeyForAppOutgoingEventId { get; protected set; } = string.Empty;

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
}
