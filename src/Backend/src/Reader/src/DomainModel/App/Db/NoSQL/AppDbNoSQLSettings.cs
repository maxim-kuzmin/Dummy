namespace Makc.Dummy.Reader.DomainModel.App.Db.NoSQL;

/// <summary>
/// Настройки базы данных NoSQL приложения.
/// </summary>
public abstract record AppDbNoSQLSettings
{
  /// <summary>
  /// Сущности.
  /// </summary>
  public AppDbNoSQLSettingsEntities Entities { get; protected set; } = null!;
}
