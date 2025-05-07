namespace Makc.Dummy.Writer.Apps.WorkerApp.App.Config.Options.Sections.Domain.AppDb.Migration;

/// <summary>
/// Раздел миграции базы данных приложения в параметрах конфигурации предметной области приложения.
/// </summary>
public record AppConfigOptionsDomainAppDbMigrationSection
{
  /// <summary>
  /// Включено ли?
  /// </summary>
  public bool IsEnabled { get; set; }

  /// <summary>
  /// Следует ли заполнять базу данных тестовыми данными?
  /// </summary>
  public bool ShouldDbBePopulatedWithTestData { get; set; }

  /// <summary>
  /// Таймаут в миллисекундах для повторного подключения к базе данных в случае неудачи.
  /// </summary>
  public int TimeoutInMillisecondsToRetry { get; set; }
}
