﻿namespace Makc.Dummy.Shared.Core.App.Config.Options.Sections.Infrastructure;

/// <summary>
/// Раздел брокера сообщений "RabbitMQ" в параметрах конфигурации инфраструктуры приложения.
/// </summary>
public record AppConfigOptionsInfrastructureRabbitMQSection
{
  /// <summary>
  /// Имя хоста.
  /// </summary>
  public string HostName { get; set; } = string.Empty;

  /// <summary>
  /// Пароль.
  /// </summary>
  public string Password { get; set; } = string.Empty;

  /// <summary>
  /// Порт.
  /// </summary>
  public int Port { get; set; }

  /// <summary>
  /// Таймаут в миллисекундах для повторного подключения к брокеру сообщений в случае неудачи.
  /// </summary>
  public int TimeoutInMillisecondsToRetry { get; set; }

  /// <summary>
  /// Имя пользователя.
  /// </summary>
  public string UserName { get; set; } = string.Empty;
}
