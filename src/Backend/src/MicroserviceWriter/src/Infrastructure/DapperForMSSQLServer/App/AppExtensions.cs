namespace Makc.Dummy.MicroserviceWriter.Infrastructure.DapperForMSSQLServer.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к Dapper для базы данных MS SQL Server.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appConfigOptions">Параметры конфигурации приложения.</param>
  /// <param name="configuration">Конфигурация.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToDapperForMSSQLServer(
    this IServiceCollection services,
    ILogger logger,
    AppConfigOptionsInfrastructureDbMSSQLServerSection appConfigOptions,
    IConfiguration configuration)
  {
    var connectionStringTemplate = configuration.GetConnectionString(appConfigOptions.ConnectionStringName);

    Guard.Against.Null(connectionStringTemplate);

    var connectionString = appConfigOptions.ToConnectionString(connectionStringTemplate);

    services.AddScoped<IAppDbContext>(x => new AppDbContext(connectionString));

    logger.LogInformation("Added application infrastructure tied to Dapper for MS SQL Server");

    return services;
  }
}
