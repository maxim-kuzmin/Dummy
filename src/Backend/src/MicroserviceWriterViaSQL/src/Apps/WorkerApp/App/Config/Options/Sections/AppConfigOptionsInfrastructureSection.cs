namespace Makc.Dummy.MicroserviceWriterViaSQL.Apps.WorkerApp.App.Config.Options.Sections;

/// <summary>
/// Раздел параметров конфигурации инфраструктуры приложения.
/// </summary>
public record AppConfigOptionsInfrastructureSection
{
  /// <summary>
  /// Брокер сообщений "Kafka".
  /// </summary>
  public AppConfigOptionsMessageBrokerSection? Kafka { get; set; }

  /// <summary>
  /// База данных "MS SQL Server".
  /// </summary>
  public AppConfigOptionsInfrastructureDbMSSQLServerSection? MSSQLServer { get; set; }

  /// <summary>
  /// Наблюдаемость.
  /// </summary>
  public AppConfigOptionsInfrastructureObservabilitySection? Observability { get; set; }

  /// <summary>
  /// База данных "PostgreSQL".
  /// </summary>
  public AppConfigOptionsInfrastructureDbPostgreSQLSection? PostgreSQL { get; set; }

  /// <summary>
  /// Брокер сообщений "RabbitMQ".
  /// </summary>
  public AppConfigOptionsInfrastructureRabbitMQSection? RabbitMQ { get; set; }
}
