namespace Makc.Dummy.Gateway.Apps.WebApp.App.Config.Options.Sections;

/// <summary>
/// Раздел параметров конфигурации интеграции приложения.
/// </summary>
public record AppConfigOptionsIntegrationSection
{
  /// <summary>
  /// Микросервис "Читатель".
  /// </summary>
  public AppConfigOptionsIntegrationMicroserviceReaderViaNoSQLSection? MicroserviceReaderViaNoSQL { get; set; }

  /// <summary>
  /// Микросервис "Писатель".
  /// </summary>
  public AppConfigOptionsIntegrationMicrocerviceWriterSection? MicroserviceWriterViaSQL { get; set; }
}
