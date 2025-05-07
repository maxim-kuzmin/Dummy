namespace Makc.Dummy.Gateway.Apps.WebApp.App.Config.Options.Sections;

/// <summary>
/// Раздел параметров конфигурации микросервисов приложения.
/// </summary>
public record AppConfigOptionsMicroservicesSection
{
  /// <summary>
  /// Микросервис "Читатель".
  /// </summary>
  public AppConfigOptionsMicroservicesReaderSection? Reader { get; set; }

  /// <summary>
  /// Микросервис "Писатель".
  /// </summary>
  public AppConfigOptionsMicrocervicesWriterSection? Writer { get; set; }
}
