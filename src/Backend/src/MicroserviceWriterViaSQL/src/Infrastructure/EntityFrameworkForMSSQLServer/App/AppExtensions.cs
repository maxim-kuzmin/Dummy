namespace Makc.Dummy.MicroserviceWriterViaSQL.Infrastructure.EntityFrameworkForMSSQLServer.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к Entity Framework для базы данных MS SQL Server.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appConfigOptions">Параметры конфигурации приложения.</param>
  /// <param name="configuration">Конфигурация.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToEntityFrameworkForMSSQLServer(
    this IServiceCollection services,
    ILogger logger,
    AppConfigOptionsInfrastructureDbMSSQLServerSection appConfigOptions,
    IConfiguration configuration)
  {
    var connectionStringTemplate = configuration.GetConnectionString(appConfigOptions.ConnectionStringName);

    Guard.Against.Null(connectionStringTemplate);

    var connectionString = appConfigOptions.ToConnectionString(connectionStringTemplate);

    services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
      connectionString,
      b => b.MigrationsAssembly(Assembly.GetExecutingAssembly())).EnableSensitiveDataLogging());

    logger.LogInformation("Added application infrastructure tied to Entity Framework for MS SQL Server");

    return services;
  }
}
