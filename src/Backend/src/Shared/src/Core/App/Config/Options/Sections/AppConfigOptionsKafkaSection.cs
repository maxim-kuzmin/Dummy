﻿namespace Makc.Dummy.Shared.Core.App.Config.Options.Sections;

/// <summary>
/// Раздел брокера сообщений Kafka в параметрах конфигурации приложения.
/// </summary>
public record AppConfigOptionsKafkaSection
{
  /// <summary>
  /// Таймаут в миллисекундах для повторного подключения к брокеру сообщений в случае неудачи.
  /// </summary>
  public int TimeoutInMillisecondsToRetry { get; set; }
}
