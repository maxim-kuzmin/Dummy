namespace Makc.Dummy.Writer.DomainModel.AppEvent.Entity.Db;

/// <summary>
/// Настройки базы данных сущности события приложения.
/// </summary>
public abstract record AppEventEntityDbSettings : AppEventEntitySettings
{
  /// <summary>
  /// Столбец для токена конкуренции.
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
  /// Столбец для признака опубликованности.
  /// </summary>
  public string ColumnForIsPublished { get; protected set; } = string.Empty;

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
}
