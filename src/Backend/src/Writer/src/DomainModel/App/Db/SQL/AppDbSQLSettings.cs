namespace Makc.Dummy.Writer.DomainModel.App.Db.SQL;

/// <summary>
/// Настройки базы данных приложения.
/// </summary>
public abstract record AppDbSQLSettings
{
  /// <summary>
  /// Сущности.
  /// </summary>
  public AppDbSQLSettingsEntities Entities { get; protected set; } = null!;

  /// <summary>
  /// Схема.
  /// </summary>
  protected string Schema { get; set; } = string.Empty;
}
