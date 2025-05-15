namespace Makc.Dummy.MicroserviceWriter.DomainModel.AppOutgoingEvent.Entity.Db.SQL;

/// <summary>
/// Настройки базы данных SQL сущности исходящего события приложения.
/// </summary>
public abstract record AppOutgoingEventEntityDbSQLSettings : AppOutgoingEventEntitySettings
{
  /// <summary>
  /// Столбец для токена параллелизма.
  /// </summary>
  public string ColumnForConcurrencyToken { get; protected set; } = string.Empty;

  /// <summary>
  /// Столбец для даты создания.
  /// </summary>
  public string ColumnForCreatedAt { get; protected set; } = string.Empty;

  /// <summary>
  /// Столбец для идентификатора.
  /// </summary>
  public string ColumnForId { get; protected set; } = string.Empty;

  /// <summary>
  /// Столбец для имени.
  /// </summary>
  public string ColumnForName { get; protected set; } = string.Empty;

  /// <summary>
  /// Столбец для даты публикации.
  /// </summary>
  public string ColumnForPublishedAt { get; protected set; } = string.Empty;

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
