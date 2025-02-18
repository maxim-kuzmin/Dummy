namespace Makc.Dummy.Writer.Infrastructure.DapperForMSSQLServer.App;

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
  /// <param name="appConfigOptionsMSSQLServerSection">
  /// Раздел базы данных MSSQLServer в параметрах конфигурации приложения.
  /// </param>
  /// <param name="configuration">Конфигурация.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToDapperForMSSQLServer(
    this IServiceCollection services,
    ILogger logger,
    AppConfigOptionsDbMSSQLServerSection? appConfigOptionsMSSQLServerSection,
    IConfiguration configuration)
  {
    Guard.Against.Null(appConfigOptionsMSSQLServerSection, nameof(appConfigOptionsMSSQLServerSection));

    var connectionStringTemplate = configuration.GetConnectionString(
      appConfigOptionsMSSQLServerSection.ConnectionStringName);

    Guard.Against.Null(connectionStringTemplate, nameof(connectionStringTemplate));

    var connectionString = appConfigOptionsMSSQLServerSection.ToConnectionString(connectionStringTemplate);

    services.AddScoped<IAppDbContext>(x => new AppDbContext(connectionString));

    logger.LogInformation("Added application infrastructure tied to Dapper for MS SQL Server");

    return services;
  }
}
