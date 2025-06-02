namespace Makc.Dummy.MicroserviceReader.Apps.WorkerApp.App.Config.Options.Sections.Domain.AppInbox.Processor;

/// <summary>
/// Раздел обработчика исходящих сообщений приложения в параметрах конфигурации предметной области приложения.
/// </summary>
public record AppConfigOptionsDomainAppInboxProcessorSection
{
  /// <summary>
  /// Максимальное количество событий для обработки.
  /// </summary>
  public int EventMaxCountToProcess { get; set; }

  /// <summary>
  /// Имена событий.
  /// </summary>
  public AppEventNameEnum[]? EventNames { get; set; }

  /// <summary>
  /// Таймаут в миллисекундах для повторения.
  /// </summary>
  public int TimeoutInMillisecondsToRepeat { get; set; }

  /// <summary>
  /// Таймаут в миллисекундах для старта.
  /// </summary>
  public int TimeoutInMillisecondsToStart { get; set; }
}
