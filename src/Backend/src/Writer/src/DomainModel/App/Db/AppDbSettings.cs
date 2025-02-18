namespace Makc.Dummy.Writer.DomainModel.App.Db;

/// <summary>
/// Настройки базы данных приложения.
/// </summary>
public abstract record AppDbSettings
{
  /// <summary>
  /// Сущности.
  /// </summary>
  public AppDbSettingsEntities Entities { get; protected set; } = null!;

  /// <summary>
  /// Схема.
  /// </summary>
  protected string Schema { get; set; } = string.Empty;
}
