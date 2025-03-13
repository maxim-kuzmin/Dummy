namespace Makc.Dummy.Reader.Infrastructure.MongoDB.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к MongoDB.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appConfigOptionsMongoDBSection">Раздел MongoDB в параметрах конфигурации приложения.</param>
  /// <param name="configuration">Конфигурация.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToMongoDB(
    this IServiceCollection services,
    ILogger logger,
    AppConfigOptionsDbMongoDBSection? appConfigOptionsMongoDBSection,
    IConfiguration configuration)
  {
    Guard.Against.Null(appConfigOptionsMongoDBSection, nameof(appConfigOptionsMongoDBSection));

    var connectionStringTemplate = configuration.GetConnectionString(
      appConfigOptionsMongoDBSection.ConnectionStringName);

    Guard.Against.Null(connectionStringTemplate, nameof(connectionStringTemplate));

    var connectionString = appConfigOptionsMongoDBSection.ToConnectionString(connectionStringTemplate);

    services.AddSingleton<IMongoClient>(x =>
    {
      IEnumerable<IEntityConfiguration> entityConfigurations = [
        new DummyItemEntityConfiguration()
      ];

      entityConfigurations.Configure();

      return new MongoClient(connectionString);
    });

    services.AddSingleton(x =>
      x.GetRequiredService<IMongoClient>().GetDatabase(appConfigOptionsMongoDBSection.Database));

    services.AddScoped(x => x.GetRequiredService<IMongoClient>().StartSession());

    services.AddTransient<IDummyItemQueryService, DummyItemQueryService>();

    logger.LogInformation("Added application infrastructure tied to MongoDB");

    return services;
  }
}
