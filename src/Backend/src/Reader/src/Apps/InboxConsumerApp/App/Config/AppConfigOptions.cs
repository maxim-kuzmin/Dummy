using Makc.Dummy.Shared.Core.App.Config.Options.Enums.Message;

namespace Makc.Dummy.Reader.Apps.InboxConsumerApp.App.Config;

/// <summary>
/// Параметры конфигурации приложения.
/// </summary>
public record AppConfigOptions : AppConfigOptionsBase
{  /// <summary>
   /// Брокер сообщений Kafka.
   /// </summary>
  public AppConfigOptionsKafkaSection? Kafka { get; set; }

  /// <summary>
  /// Брокер сообщений.
  /// </summary>
  public AppConfigOptionsMessageBrokerEnum MessageBroker { get; set; } = AppConfigOptionsMessageBrokerEnum.Kafka;

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
