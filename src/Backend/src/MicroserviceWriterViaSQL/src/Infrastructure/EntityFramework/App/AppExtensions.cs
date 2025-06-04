namespace Makc.Dummy.MicroserviceWriterViaSQL.Infrastructure.EntityFramework.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к Entity Framework.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appDbSQLSettings">Настройки базы данных SQL приложения.</param>
  /// <param name="appConfigOptionsORM">ORM в параметрах конфигурации приложения.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToEntityFramework(
    this IServiceCollection services,
    ILogger logger,
    AppDbSQLSettings appDbSQLSettings,
    AppConfigOptionsORMEnum appConfigOptionsORM)
  {
    AppDbContext.Init(appDbSQLSettings);

    services.AddScoped<IAppDbSQLExecutionContext, AppDbSQLExecutionContext>();

    if (appConfigOptionsORM == AppConfigOptionsORMEnum.EntityFramework)
    {
      services.AddScoped<IAppDbSQLQueryContext, AppDbSQLQueryContext>();
    }

    services.AddScoped(typeof(IRepository<>), typeof(AppRepositoryBase<>));
    services.AddScoped(typeof(IReadRepository<>), typeof(AppRepositoryBase<>));

    services.AddScoped<IAppOutgoingEventRepository, AppOutgoingEventRepository>();
    services.AddScoped<IAppOutgoingEventPayloadRepository, AppOutgoingEventPayloadRepository>();
    services.AddScoped<IDummyItemRepository, DummyItemRepository>();    

    logger.LogInformation("Added application infrastructure tied to Entity Framework");

    return services;
  }
}
