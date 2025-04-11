namespace Makc.Dummy.Writer.Apps.DbMigrationApp.App.Config;

/// <summary>
/// Параметры конфигурации приложения.
/// </summary>
public record AppConfigOptions : AppConfigOptionsBase
{
  /// <summary>
  /// База данных.
  /// </summary>
  public AppConfigOptionsDbEnum Db { get; set; } = AppConfigOptionsDbEnum.PostgreSQL;

  /// <summary>
  /// ORM запросов базы данных.
  /// </summary>
  public AppConfigOptionsORMEnum DbQueryORM { get; set; } = AppConfigOptionsORMEnum.EntityFramework;

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
  /// Следует ли заполнять базу данных тестовыми данными?
  /// </summary>
  public bool ShouldDbBePopulatedWithTestData { get; set; }

  /// <summary>
  /// Таймаут в миллисекундах для повторного подключения к базе данных в случае неудачи.
  /// </summary>
  public int TimeoutInMillisecondsToRetry { get; set; }
}
