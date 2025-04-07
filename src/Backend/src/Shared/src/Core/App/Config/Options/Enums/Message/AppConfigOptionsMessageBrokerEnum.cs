namespace Makc.Dummy.Shared.Core.App.Config.Options.Enums.Message;

/// <summary>
/// Перечисление брокеров сообщений в параметрах конфигурации приложения.
/// </summary>
public enum AppConfigOptionsMessageBrokerEnum
{
  /// <summary>
  /// Kafka.
  /// </summary>
  Kafka = 1,
  /// <summary>
  /// RabbitMQ.
  /// </summary>
  RabbitMQ
}
