namespace Makc.Dummy.Reader.Apps.WorkerApp.App.Config.Options.Sections;

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
  /// Входящие сообщения приложения.
  /// </summary>
  public AppConfigOptionsDomainAppInboxSection? AppInbox { get; set; }
}
