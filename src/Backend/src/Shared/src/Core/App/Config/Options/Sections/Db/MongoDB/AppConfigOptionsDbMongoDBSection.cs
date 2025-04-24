namespace Makc.Dummy.Shared.Core.App.Config.Options.Sections.Db.MongoDB;

/// <summary>
/// Раздел базы данных MongoDB в параметрах конфигурации приложения.
/// </summary>
public record AppConfigOptionsDbMongoDBSection : AppConfigOptionsDbSection
{
  /// <summary>
  /// Набор реплик.
  /// </summary>
  public string ReplicaSet { get; set; } = string.Empty;

  /// <inheritdoc/>
  public override string ToConnectionString(string template)
  {
    return base.ToConnectionString(template).Replace("{ReplicaSet}", ReplicaSet);
  }
}
