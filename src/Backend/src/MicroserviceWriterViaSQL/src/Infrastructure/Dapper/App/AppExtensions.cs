namespace Makc.Dummy.MicroserviceWriterViaSQL.Infrastructure.Dapper.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к Dapper.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appConfigOptionsORM">ORM в параметрах конфигурации приложения.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToDapper(
    this IServiceCollection services,
    ILogger logger,
    AppConfigOptionsORMEnum appConfigOptionsORM)
  {
    if (appConfigOptionsORM == AppConfigOptionsORMEnum.Dapper)
    {
      services.AddScoped<IAppDbSQLQueryContext, AppDbQueryContext>();
    }

    logger.LogInformation("Added application infrastructure tied to Dapper");

    return services;
  }
}
