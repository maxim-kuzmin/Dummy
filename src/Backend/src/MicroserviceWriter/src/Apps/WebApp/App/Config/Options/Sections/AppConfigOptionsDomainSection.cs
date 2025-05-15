using Makc.Dummy.Shared.Core.App.Config.Options.Sections.Domain;

namespace Makc.Dummy.MicroserviceWriter.Apps.WebApp.App.Config.Options.Sections;

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
  public AppConfigOptionsDomainAuthSection? Auth { get; set; }
}
