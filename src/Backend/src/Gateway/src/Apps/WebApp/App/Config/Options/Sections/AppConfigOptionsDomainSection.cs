namespace Makc.Dummy.Gateway.Apps.WebApp.App.Config.Options.Sections;

/// <summary>
/// Раздел параметров конфигурации предметной области приложения.
/// </summary>
public record AppConfigOptionsDomainSection
{
  /// <summary>
  /// Аутентификация.
  /// </summary>
  public AppConfigOptionsDomainAuthSection? Auth { get; set; }
}
