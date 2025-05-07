namespace Makc.Dummy.Reader.Apps.WebApp.App.Config.Options.Sections;

/// <summary>
/// Раздел параметров конфигурации инфраструктуры приложения.
/// </summary>
public record AppConfigOptionsInfrastructureSection
{
  /// <summary>
  /// База данных MongoDB.
  /// </summary>
  public AppConfigOptionsDbMongoDBSection? MongoDB { get; set; }

  /// <summary>
  /// Наблюдаемость.
  /// </summary>
  public AppConfigOptionsObservabilitySection? Observability { get; set; }
}
