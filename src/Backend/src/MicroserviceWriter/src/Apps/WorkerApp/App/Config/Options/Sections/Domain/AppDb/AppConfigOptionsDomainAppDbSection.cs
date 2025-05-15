namespace Makc.Dummy.MicroserviceWriter.Apps.WorkerApp.App.Config.Options.Sections.Domain.AppDb;

/// <summary>
/// Раздел базы данных приложения в параметрах конфигурации предметной области приложения.
/// </summary>
public record AppConfigOptionsDomainAppDbSection
{
  /// <summary>
  /// Миграция.
  /// </summary>
  public AppConfigOptionsDomainAppDbMigrationSection? Migration { get; set; }
}
