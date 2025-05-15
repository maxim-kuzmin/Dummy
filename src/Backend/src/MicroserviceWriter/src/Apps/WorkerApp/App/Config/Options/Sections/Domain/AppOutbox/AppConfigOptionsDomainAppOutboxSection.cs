namespace Makc.Dummy.MicroserviceWriter.Apps.WorkerApp.App.Config.Options.Sections.Domain.AppOutbox;

/// <summary>
/// Раздел исходящих сообщений приложения в параметрах конфигурации предметной области приложения.
/// </summary>
public record AppConfigOptionsDomainAppOutboxSection
{
  /// <summary>
  /// Чистильщик.
  /// </summary>
  public AppConfigOptionsDomainAppOutboxCleanerSection? Cleaner { get; set; }

  /// <summary>
  /// Поставщик.
  /// </summary>
  public AppConfigOptionsDomainAppOutboxProducerSection? Producer { get; set; }
}
