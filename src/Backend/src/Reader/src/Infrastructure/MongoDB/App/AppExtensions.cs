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
  /// <param name="appConfigOptions">Параметры конфигурации приложения.</param>
  /// <param name="configuration">Конфигурация.</param>
  /// <param name="appDbNoSQLSettings">Настройки базы данных NoSQL приложения.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToMongoDB(
    this IServiceCollection services,
    ILogger logger,
    AppConfigOptionsInfrastructureDbMongoDBSection appConfigOptions,
    IConfiguration configuration,
    out AppDbNoSQLSettings appDbNoSQLSettings)
  {
    appDbNoSQLSettings = new AppDbSettings();

    services.AddSingleton((AppDbSettings)appDbNoSQLSettings);

    services.AddSingleton(appDbNoSQLSettings.Entities.AppIncomingEvent);
    services.AddSingleton(appDbNoSQLSettings.Entities.AppIncomingEventPayload);
    services.AddSingleton(appDbNoSQLSettings.Entities.DummyItem);

    var connectionStringTemplate = configuration.GetConnectionString(
      appConfigOptions.ConnectionStringName);

    Guard.Against.Null(connectionStringTemplate);

    var connectionString = appConfigOptions.ToConnectionString(connectionStringTemplate);

    services.AddSingleton<IMongoClient>(x =>
    {
      BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

      IEnumerable<IEntityConfiguration> entityConfigurations = [
        new AppIncomingEventEntityConfiguration(),
        new AppIncomingEventPayloadEntityConfiguration(),
        new DummyItemEntityConfiguration()
      ];

      entityConfigurations.Configure();

      return new MongoClient(connectionString);
    });

    services.AddSingleton(x =>
      x.GetRequiredService<IMongoClient>().GetDatabase(appConfigOptions.Database));

    services.AddScoped(x => x.GetRequiredService<IMongoClient>().StartSession());

    services.AddScoped<IAppDbNoSQLExecutionContext, AppDbExecutionContext>();

    services.AddTransient<IAppIncomingEventRepository, AppIncomingEventRepository>();
    services.AddTransient<IAppIncomingEventPayloadRepository, AppIncomingEventPayloadRepository>();
    services.AddTransient<IDummyItemRepository, DummyItemRepository>();    

    logger.LogInformation("Added application infrastructure tied to MongoDB");

    return services;
  }
}
