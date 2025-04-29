namespace Makc.Dummy.Reader.Infrastructure.MongoDB.App.Db;

/// <summary>
/// Настройки базы данных приложения.
/// </summary>
public record AppDbSettings : AppDbNoSQLSettings
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  public AppDbSettings()
  {
    Entities = new AppDbSettingsEntities();    
  }
}
