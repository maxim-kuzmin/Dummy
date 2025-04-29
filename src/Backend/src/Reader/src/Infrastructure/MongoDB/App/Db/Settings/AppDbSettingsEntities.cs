namespace Makc.Dummy.Reader.Infrastructure.MongoDB.App.Db.Settings;

/// <summary>
/// Сущности в настройках базы данных приложения.
/// </summary>
public record AppDbSettingsEntities : AppDbNoSQLSettingsEntities
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="schema">Схема.</param>
  public AppDbSettingsEntities()
  {
    DummyItem = new DummyItemEntityDbSettings();
  }
}
