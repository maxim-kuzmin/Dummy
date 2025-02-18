namespace Makc.Dummy.Writer.Infrastructure.EntityFrameworkForMSSQLServer.App;

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
  /// <param name="appConfigOptionsMSSQLServerSection">
  /// Раздел базы данных MSSQLServer в параметрах конфигурации приложения.
  /// </param>
  /// <param name="configuration">Конфигурация.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToEntityFrameworkForMSSQLServer(
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

    services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
      connectionString,
      b => b.MigrationsAssembly(Assembly.GetExecutingAssembly())));

    logger.LogInformation("Added application infrastructure tied to Entity Framework for MS SQL Server");

    return services;
  }
}
