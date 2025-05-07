namespace Makc.Dummy.Writer.Apps.WorkerApp.App.Config.Options.Sections.Domain.App;

/// <summary>
/// Раздел приложения в параметрах конфигурации предметной области приложения.
/// </summary>
public record AppConfigOptionsDomainAppSection
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
  /// Брокер сообщений.
  /// </summary>
  public AppConfigOptionsMessageBrokerEnum MessageBroker { get; set; } = AppConfigOptionsMessageBrokerEnum.Kafka;
}
