namespace Makc.Dummy.Writer.Infrastructure.EntityFrameworkForPostgreSQL.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к Entity Framework для базы данных PostgreSQL.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appConfigOptions">Параметры конфигурации приложения.</param>
  /// <param name="configuration">Конфигурация.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToEntityFrameworkForPostgreSQL(
    this IServiceCollection services,
    ILogger logger,
    AppConfigOptionsInfrastructureDbPostgreSQLSection appConfigOptions,
    IConfiguration configuration)
  {
    var connectionStringTemplate = configuration.GetConnectionString(appConfigOptions.ConnectionStringName);

    Guard.Against.Null(connectionStringTemplate);

    var connectionString = appConfigOptions.ToConnectionString(connectionStringTemplate);

    services.AddDbContext<AppDbContext>(options => options.UseNpgsql(
      connectionString,
      b => b.MigrationsAssembly(Assembly.GetExecutingAssembly())));

    logger.LogInformation("Added application infrastructure tied to Entity Framework for PostgreSQL");

    return services;
  }
}
