namespace Makc.Dummy.MicroserviceWriter.Apps.WorkerApp.App.Config.Options.Sections.Domain.AppOutbox.Producer;

/// <summary>
/// Раздел поставщика исходящих сообщений приложения в параметрах конфигурации предметной области приложения.
/// </summary>
public record AppConfigOptionsDomainAppOutboxProducerSection
{
  /// <summary>
  /// Максимальное количество событий, публикуемых за одно повторение.
  /// </summary>
  public int MaxCount { get; set; }

  /// <summary>
  /// Таймаут в миллисекундах для повторения.
  /// </summary>
  public int TimeoutInMillisecondsToRepeat { get; set; }
}
