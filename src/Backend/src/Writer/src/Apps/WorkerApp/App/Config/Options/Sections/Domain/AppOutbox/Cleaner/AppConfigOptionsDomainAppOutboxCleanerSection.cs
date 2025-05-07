namespace Makc.Dummy.Writer.Apps.WorkerApp.App.Config.Options.Sections.Domain.AppOutbox.Cleaner;

/// <summary>
/// Раздел чистильщика исходящих сообщений приложения в параметрах конфигурации предметной области приложения.
/// </summary>
public record AppConfigOptionsDomainAppOutboxCleanerSection
{
  /// <summary>
  /// Включено ли?
  /// </summary>
  public bool IsEnabled { get; set; }
}
