namespace Makc.Dummy.MicroserviceWriter.Domain.Model.App.Db.SQL;

/// <summary>
/// Настройки базы данных SQL приложения.
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
