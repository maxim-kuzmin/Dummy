namespace Makc.Dummy.Writer.DomainModel.App.Db.SQL.Settings;

/// <summary>
/// Сущности в настройках базы данных приложения.
/// </summary>
public abstract record AppDbSQLSettingsEntities
{
  /// <summary>
  /// Событие приложения.
  /// </summary>
  public AppEventEntityDbSQLSettings AppEvent { get; protected set; } = null!;

  /// <summary>
  /// Полезная нагрузка события приложения.
  /// </summary>
  public AppEventPayloadEntityDbSQLSettings AppEventPayload { get; protected set; } = null!;

  /// <summary>
  /// Фиктивный предмет.
  /// </summary>
  public DummyItemEntityDbSQLSettings DummyItem { get; protected set; } = null!;
}
