namespace Makc.Dummy.Writer.Apps.WebApp.App.Config.Options.Sections;

/// <summary>
/// Раздел параметров конфигурации предметной области приложения.
/// </summary>
public record AppConfigOptionsDomainSection
{
  /// <summary>
  /// Приложение.
  /// </summary>
  public AppConfigOptionsDomainAppSection? App { get; set; }

  /// <summary>
  /// Аутентификация.
  /// </summary>
  public AppConfigOptionsAuthenticationSection? Auth { get; set; }
}
