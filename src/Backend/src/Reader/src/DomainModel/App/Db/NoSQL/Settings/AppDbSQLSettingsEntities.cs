namespace Makc.Dummy.Reader.DomainModel.App.Db.NoSQL.Settings;

/// <summary>
/// Сущности в настройках базы данных приложения.
/// </summary>
public abstract record AppDbSQLSettingsEntities
{
  /// <summary>
  /// Фиктивный предмет.
  /// </summary>
  public DummyItemEntityDbNoSQLSettings DummyItem { get; protected set; } = null!;
}
