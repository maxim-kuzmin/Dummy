namespace Makc.Dummy.MicroserviceReader.Domain.Model.App.Db.NoSQL;

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
