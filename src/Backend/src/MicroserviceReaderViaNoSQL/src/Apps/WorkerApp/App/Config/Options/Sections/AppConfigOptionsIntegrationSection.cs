namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Apps.WorkerApp.App.Config.Options.Sections;

/// <summary>
/// Раздел параметров конфигурации интеграции приложения.
/// </summary>
public record AppConfigOptionsIntegrationSection
{
  /// <summary>
  /// Микросервис "Писатель".
  /// </summary>
  public AppConfigOptionsIntegrationMicrocerviceWriterSection? MicroserviceWriterViaSQL { get; set; }
}
