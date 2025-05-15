namespace Makc.Dummy.MicroserviceReader.Apps.WorkerApp.App.Config.Options.Sections.Domain.App;

/// <summary>
/// Раздел приложения в параметрах конфигурации предметной области приложения.
/// </summary>
public record AppConfigOptionsDomainAppSection
{
  /// <summary>
  /// Брокер сообщений.
  /// </summary>
  public AppConfigOptionsMessageBrokerEnum MessageBroker { get; set; } = AppConfigOptionsMessageBrokerEnum.Kafka;
}
