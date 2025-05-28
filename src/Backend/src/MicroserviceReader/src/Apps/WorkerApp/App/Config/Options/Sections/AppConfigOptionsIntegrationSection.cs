namespace Makc.Dummy.MicroserviceReader.Apps.WorkerApp.App.Config.Options.Sections;

/// <summary>
/// Раздел параметров конфигурации интеграции приложения.
/// </summary>
public record AppConfigOptionsIntegrationSection
{
  /// <summary>
  /// Микросервис "Писатель".
  /// </summary>
  public AppConfigOptionsIntegrationMicrocerviceWriterSection? MicroserviceWriter { get; set; }
}
