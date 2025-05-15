namespace Makc.Dummy.MicroserviceWriter.Infrastructure.MSSQLServer.App.Db;

/// <summary>
/// Настройки базы данных приложения.
/// </summary>
public record AppDbSettings : AppDbSQLSettings
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  public AppDbSettings()
  {
    Schema = "writer";
    Entities = new AppDbSettingsEntities(Schema);    
  }
}
