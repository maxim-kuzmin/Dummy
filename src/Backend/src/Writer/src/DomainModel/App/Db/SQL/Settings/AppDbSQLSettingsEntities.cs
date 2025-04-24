namespace Makc.Dummy.Writer.DomainModel.App.Db.SQL.Settings;

/// <summary>
/// Сущности в настройках базы данных приложения.
/// </summary>
public abstract record AppDbSQLSettingsEntities
{
  /// <summary>
  /// Событие приложения.
  /// </summary>
  public AppOutgoingEventEntityDbSQLSettings AppOutgoingEvent { get; protected set; } = null!;

  /// <summary>
  /// Полезная нагрузка исходящего события приложения.
  /// </summary>
  public AppOutgoingEventPayloadEntityDbSQLSettings AppOutgoingEventPayload { get; protected set; } = null!;

  /// <summary>
  /// Фиктивный предмет.
  /// </summary>
  public DummyItemEntityDbSQLSettings DummyItem { get; protected set; } = null!;
}
