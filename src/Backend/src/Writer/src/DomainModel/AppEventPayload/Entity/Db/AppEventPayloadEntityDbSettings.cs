namespace Makc.Dummy.Writer.DomainModel.AppEventPayload.Entity.Db;

/// <summary>
/// Настройки базы данных сущности полезной нагрузки события приложения.
/// </summary>
public abstract record AppEventPayloadEntityDbSettings : AppEventPayloadEntitySettings
{
  /// <summary>
  /// Столбец для токена конкуренции.
  /// </summary>
  public string ColumnForConcurrencyToken { get; protected set; } = string.Empty;

  /// <summary>
  /// Внешний ключ для идентификатора события приложения.
  /// </summary>
  public string ColumnForAppEventId { get; protected set; } = string.Empty;

  /// <summary>
  /// Столбец для данных.
  /// </summary>
  public string ColumnForData { get; protected set; } = string.Empty;

  /// <summary>
  /// Столбец для идентификатора.
  /// </summary>
  public string ColumnForId { get; protected set; } = string.Empty;

  /// <summary>
  /// Внешний ключ для идентификатора события приложения.
  /// </summary>
  public string ForeignKeyForAppEventId { get; protected set; } = string.Empty;

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
