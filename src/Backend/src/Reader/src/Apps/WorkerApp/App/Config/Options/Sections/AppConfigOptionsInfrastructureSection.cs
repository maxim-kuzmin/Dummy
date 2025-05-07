namespace Makc.Dummy.Reader.Apps.WorkerApp.App.Config.Options.Sections;

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
  public AppConfigOptionsDbMongoDBSection? MongoDB { get; set; }

  /// <summary>
  /// Наблюдаемость.
  /// </summary>
  public AppConfigOptionsObservabilitySection? Observability { get; set; }

  /// <summary>
  /// Брокер сообщений RabbitMQ.
  /// </summary>
  public AppConfigOptionsRabbitMQSection? RabbitMQ { get; set; }
}
