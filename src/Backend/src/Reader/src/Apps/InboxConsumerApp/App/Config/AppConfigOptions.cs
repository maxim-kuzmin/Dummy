﻿namespace Makc.Dummy.Reader.Apps.InboxConsumerApp.App.Config;

/// <summary>
/// Параметры конфигурации приложения.
/// </summary>
public record AppConfigOptions : AppConfigOptionsBase
{
  /// <summary>
  /// База данных PostgreSQL.
  /// </summary>
  public AppConfigOptionsDbPostgreSQLSection? PostgreSQL { get; set; }

  /// <summary>
  /// Брокер сообщений RabbitMQ.
  /// </summary>
  public AppConfigOptionsRabbitMQSection? RabbitMQ { get; set; }
}
