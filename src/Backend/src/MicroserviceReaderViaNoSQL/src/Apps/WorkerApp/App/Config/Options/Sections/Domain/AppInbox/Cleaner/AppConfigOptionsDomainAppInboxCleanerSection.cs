namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Apps.WorkerApp.App.Config.Options.Sections.Domain.AppInbox.Cleaner;

/// <summary>
/// Раздел чистильщика входящих сообщений приложения в параметрах конфигурации предметной области приложения.
/// </summary>
public record AppConfigOptionsDomainAppInboxCleanerSection
{
  /// <summary>
  /// Максимальное количество событий для очистки.
  /// </summary>
  public int EventMaxCountToClear { get; set; }

  /// <summary>
  /// Время жизни обработанных сообщений в минутах.
  /// </summary>
  public int ProcessedEventsLifetimeInMinutes { get; set; }
  
  /// <summary>
  /// Таймаут в миллисекундах для получения событий.
  /// </summary>
  public int TimeoutInMillisecondsToGetEvents { get; set; }

  /// <summary>
  /// Таймаут в миллисекундах для повторения.
  /// </summary>
  public int TimeoutInMillisecondsToRepeat { get; set; }

  /// <summary>
  /// Таймаут в миллисекундах для старта.
  /// </summary>
  public int TimeoutInMillisecondsToStart { get; set; }
}
