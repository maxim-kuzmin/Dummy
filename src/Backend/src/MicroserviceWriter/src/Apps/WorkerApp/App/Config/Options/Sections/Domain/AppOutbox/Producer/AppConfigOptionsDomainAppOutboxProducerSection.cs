namespace Makc.Dummy.MicroserviceWriter.Apps.WorkerApp.App.Config.Options.Sections.Domain.AppOutbox.Producer;

/// <summary>
/// Раздел поставщика исходящих сообщений приложения в параметрах конфигурации предметной области приложения.
/// </summary>
public record AppConfigOptionsDomainAppOutboxProducerSection
{
  /// <summary>
  /// Максимальное количество событий для публикации.
  /// </summary>
  public int EventMaxCountToPublish { get; set; }

  /// <summary>
  /// Таймаут в миллисекундах для повторения.
  /// </summary>
  public int TimeoutInMillisecondsToRepeat { get; set; }

  /// <summary>
  /// Таймаут в миллисекундах для старта.
  /// </summary>
  public int TimeoutInMillisecondsToStart { get; set; }
}
