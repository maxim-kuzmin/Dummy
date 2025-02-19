namespace Makc.Dummy.Writer.Apps.WebApp.App.Config;

/// <summary>
/// Параметры конфигурации приложения.
/// </summary>
public record AppConfigOptions : AppConfigOptionsBase
{
  /// <summary>
  /// ORM запроса действия.
  /// </summary>
  public AppConfigOptionsORMEnum ActionQueryORM { get; set; } = AppConfigOptionsORMEnum.EntityFramework;

  /// <summary>
  /// Аутентификация.
  /// </summary>
  public AppConfigOptionsAuthenticationSection? Authentication { get; set; }

  /// <summary>
  /// База данных.
  /// </summary>
  public AppConfigOptionsDbEnum Db { get; set; } = AppConfigOptionsDbEnum.PostgreSQL;

  /// <summary>
  /// База данных MS SQL Server.
  /// </summary>
  public AppConfigOptionsDbMSSQLServerSection? MSSQLServer { get; set; }

  /// <summary>
  /// Наблюдаемость.
  /// </summary>
  public AppConfigOptionsObservabilitySection? Observability { get; set; }

  /// <summary>
  /// База данных PostgreSQL.
  /// </summary>
  public AppConfigOptionsDbPostgreSQLSection? PostgreSQL { get; set; }

  /// <summary>
  /// Брокер сообщений RabbitMQ.
  /// </summary>
  public AppConfigOptionsRabbitMQSection? RabbitMQ { get; set; }
}
