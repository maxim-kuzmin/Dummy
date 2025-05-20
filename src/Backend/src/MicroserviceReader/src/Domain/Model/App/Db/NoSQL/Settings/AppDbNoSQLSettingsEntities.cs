namespace Makc.Dummy.MicroserviceReader.Domain.Model.App.Db.NoSQL.Settings;

/// <summary>
/// Сущности в настройках базы данных NoSQL приложения.
/// </summary>
public abstract record AppDbNoSQLSettingsEntities
{
  /// <summary>
  /// Входящее событие приложения.
  /// </summary>
  public AppIncomingEventEntityDbNoSQLSettings AppIncomingEvent { get; protected set; } = null!;

  /// <summary>
  /// Полезная нагрузка входящего события приложения.
  /// </summary>
  public AppIncomingEventPayloadEntityDbNoSQLSettings AppIncomingEventPayload { get; protected set; } = null!;

  /// <summary>
  /// Фиктивный предмет.
  /// </summary>
  public DummyItemEntityDbNoSQLSettings DummyItem { get; protected set; } = null!;
}
