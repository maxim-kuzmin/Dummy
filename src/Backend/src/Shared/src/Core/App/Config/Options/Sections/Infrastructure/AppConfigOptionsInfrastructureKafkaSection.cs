namespace Makc.Dummy.Shared.Core.App.Config.Options.Sections.Infrastructure;

/// <summary>
/// Раздел брокера сообщений "Kafka" в параметрах конфигурации инфраструктуры приложения.
/// </summary>
public record AppConfigOptionsInfrastructureKafkaSection
{
  /// <summary>
  /// Таймаут в миллисекундах для повторного подключения к брокеру сообщений в случае неудачи.
  /// </summary>
  public int TimeoutInMillisecondsToRetry { get; set; }
}
