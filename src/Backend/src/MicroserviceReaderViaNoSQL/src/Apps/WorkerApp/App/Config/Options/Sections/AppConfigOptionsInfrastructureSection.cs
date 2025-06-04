namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Apps.WorkerApp.App.Config.Options.Sections;

/// <summary>
/// Раздел параметров конфигурации инфраструктуры приложения.
/// </summary>
public record AppConfigOptionsInfrastructureSection
{
  /// <summary>
  /// Брокер сообщений Kafka.
  /// </summary>
  public AppConfigOptionsMessageBrokerSection? Kafka { get; set; }

  /// <summary>
  /// База данных MongoDB.
  /// </summary>
  public AppConfigOptionsInfrastructureDbMongoDBSection? MongoDB { get; set; }

  /// <summary>
  /// Наблюдаемость.
  /// </summary>
  public AppConfigOptionsInfrastructureObservabilitySection? Observability { get; set; }

  /// <summary>
  /// Брокер сообщений RabbitMQ.
  /// </summary>
  public AppConfigOptionsInfrastructureRabbitMQSection? RabbitMQ { get; set; }
}
