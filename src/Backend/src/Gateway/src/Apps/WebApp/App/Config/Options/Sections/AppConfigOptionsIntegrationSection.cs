namespace Makc.Dummy.Gateway.Apps.WebApp.App.Config.Options.Sections;

/// <summary>
/// Раздел параметров конфигурации интеграции приложения.
/// </summary>
public record AppConfigOptionsIntegrationSection
{
  /// <summary>
  /// Микросервис "Читатель".
  /// </summary>
  public AppConfigOptionsIntegrationMicroserviceReaderSection? MicroserviceReader { get; set; }

  /// <summary>
  /// Микросервис "Писатель".
  /// </summary>
  public AppConfigOptionsIntegrationMicrocerviceWriterSection? MicroserviceWriter { get; set; }
}
