namespace Makc.Dummy.Writer.Infrastructure.DapperForPostgreSQL.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к Dapper для базы данных PostgreSQL.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appConfigOptionsPostgreSQLSection">
  /// Раздел базы данных PostgreSQL в параметрах конфигурации приложения.
  /// </param>
  /// <param name="configuration">Конфигурация.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToDapperForPostgreSQL(
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

    services.AddScoped<IAppDbContext>(x => new AppDbContext(connectionString));

    logger.LogInformation("Added application infrastructure tied to Dapper for PostgreSQL");

    return services;
  }
}
