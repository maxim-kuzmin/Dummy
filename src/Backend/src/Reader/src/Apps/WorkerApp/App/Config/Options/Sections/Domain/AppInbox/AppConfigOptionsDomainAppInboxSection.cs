namespace Makc.Dummy.Reader.Apps.WorkerApp.App.Config.Options.Sections.Domain.AppInbox;

/// <summary>
/// Раздел входящих сообщений приложения в параметрах конфигурации предметной области приложения.
/// </summary>
public record AppConfigOptionsDomainAppInboxSection
{
  /// <summary>
  /// Чистильщик.
  /// </summary>
  public AppConfigOptionsDomainAppInboxCleanerSection? Cleaner { get; set; }

  /// <summary>
  /// Поставщик.
  /// </summary>
  public AppConfigOptionsDomainAppInboxConsumerSection? Consumer { get; set; }
}
