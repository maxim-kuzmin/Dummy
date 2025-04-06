namespace Makc.Dummy.Shared.Core.App.Config.Options.Enums;

/// <summary>
/// Перечисление шин сообщений в параметрах конфигурации приложения.
/// </summary>
public enum AppConfigOptionsMessageBusEnum
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
