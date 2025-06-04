namespace Makc.Dummy.MicroserviceWriterViaSQL.Apps.WorkerApp.App.Config.Options.Sections.Domain.AppOutbox.Cleaner;

/// <summary>
/// Раздел чистильщика исходящих сообщений приложения в параметрах конфигурации предметной области приложения.
/// </summary>
public record AppConfigOptionsDomainAppOutboxCleanerSection
{
  /// <summary>
  /// Время жизни опубликованных сообщений в минутах.
  /// </summary>
  public int PublishedEventsLifetimeInMinutes { get; set; }

  /// <summary>
  /// Таймаут в миллисекундах для повторения.
  /// </summary>
  public int TimeoutInMillisecondsToRepeat { get; set; }

  /// <summary>
  /// Таймаут в миллисекундах для старта.
  /// </summary>
  public int TimeoutInMillisecondsToStart { get; set; }
}
