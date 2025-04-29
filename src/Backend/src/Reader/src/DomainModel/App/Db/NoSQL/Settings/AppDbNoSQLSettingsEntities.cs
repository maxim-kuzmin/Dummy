namespace Makc.Dummy.Reader.DomainModel.App.Db.NoSQL.Settings;

/// <summary>
/// Сущности в настройках базы данных NoSQL приложения.
/// </summary>
public abstract record AppDbNoSQLSettingsEntities
{
  /// <summary>
  /// Фиктивный предмет.
  /// </summary>
  public DummyItemEntityDbNoSQLSettings DummyItem { get; protected set; } = null!;
}
