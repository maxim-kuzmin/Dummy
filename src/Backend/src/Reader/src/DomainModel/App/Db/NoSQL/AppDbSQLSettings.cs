namespace Makc.Dummy.Reader.DomainModel.App.Db.NoSQL;

/// <summary>
/// Настройки базы данных приложения.
/// </summary>
public abstract record AppDbSQLSettings
{
  /// <summary>
  /// Сущности.
  /// </summary>
  public AppDbSQLSettingsEntities Entities { get; protected set; } = null!;
}
