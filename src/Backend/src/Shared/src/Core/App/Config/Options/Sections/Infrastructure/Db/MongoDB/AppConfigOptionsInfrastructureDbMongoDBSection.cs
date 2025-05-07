namespace Makc.Dummy.Shared.Core.App.Config.Options.Sections.Infrastructure.Db.MongoDB;

/// <summary>
/// Раздел базы данных "MongoDB" в параметрах конфигурации инфраструктуры приложения.
/// </summary>
public record AppConfigOptionsInfrastructureDbMongoDBSection : AppConfigOptionsInfrastructureDbSection
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
