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
  /// <param name="appConfigOptionsPostgreSQLSection">
  /// Раздел базы данных PostgreSQL в параметрах конфигурации приложения.
  /// </param>
  /// <param name="configuration">Конфигурация.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToEntityFrameworkForPostgreSQL(
    this IServiceCollection services,
    ILogger logger,
    AppConfigOptionsDbPostgreSQLSection? appConfigOptionsPostgreSQLSection,
    IConfiguration configuration)
  {
    Guard.Against.Null(appConfigOptionsPostgreSQLSection, nameof(appConfigOptionsPostgreSQLSection));

    var connectionStringTemplate = configuration.GetConnectionString(
      appConfigOptionsPostgreSQLSection.ConnectionStringName);

    Guard.Against.Null(connectionStringTemplate, nameof(connectionStringTemplate));

    var connectionString = appConfigOptionsPostgreSQLSection.ToConnectionString(connectionStringTemplate);

    services.AddDbContext<AppDbContext>(options => options.UseNpgsql(
      connectionString,
      b => b.MigrationsAssembly(Assembly.GetExecutingAssembly())));

    logger.LogInformation("Added application infrastructure tied to Entity Framework for PostgreSQL");

    return services;
  }
}
