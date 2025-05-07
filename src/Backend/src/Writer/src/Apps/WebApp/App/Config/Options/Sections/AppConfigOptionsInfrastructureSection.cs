using Makc.Dummy.Shared.Core.App.Config.Options.Sections.Infrastructure;
using Makc.Dummy.Shared.Core.App.Config.Options.Sections.Infrastructure.Db.MSSQLServer;
using Makc.Dummy.Shared.Core.App.Config.Options.Sections.Infrastructure.Db.PostgreSQL;

namespace Makc.Dummy.Writer.Apps.WebApp.App.Config.Options.Sections;

/// <summary>
/// Раздел параметров конфигурации инфраструктуры приложения.
/// </summary>
public record AppConfigOptionsInfrastructureSection
{
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
