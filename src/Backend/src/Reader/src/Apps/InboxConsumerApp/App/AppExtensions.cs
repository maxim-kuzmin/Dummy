using Makc.Dummy.Shared.Core.App.Config.Options.Sections.Db.MongoDB;

namespace Makc.Dummy.Reader.Apps.InboxConsumerApp.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Построить приложение.
  /// </summary>
  /// <param name="appBuilder">Построитель приложения.</param>
  /// <param name="logger">Логгер.</param>
  /// <returns>Приложение.</returns>
  public static IHost BuildApp(this HostApplicationBuilder appBuilder, ILogger logger)
  {
    var appConfigSection = appBuilder.Configuration.GetSection("App");

    var appConfigOptions = new AppConfigOptions();

    appConfigSection.Bind(appConfigOptions);

    Thread.CurrentThread.CurrentUICulture =
      Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(appConfigOptions.DefaultLanguage);

    var services = appBuilder.Services.Configure<AppConfigOptions>(appConfigSection)
      .AddAppDomainModel(logger)
      .AddAppDomainUseCases(logger);

    List<AppLoggerFuncToConfigure> funcsToConfigureAppLogger = [];

    if (appConfigOptions.Observability != null)
    {
      services
        .AddAppSharedInfrastructureTiedToCoreForOpenTelemetry(
          logger,
          appConfigOptions.Observability,
          funcToConfigureAppMetrics: null,
          funcToConfigureAppTracing: null,
          out var funcToConfigureAppLogger);

      if (funcToConfigureAppLogger != null)
      {
        funcsToConfigureAppLogger.Add(funcToConfigureAppLogger);
      }
    }

    services
      .AddAppSharedInfrastructureTiedToCore(logger, appBuilder.Configuration, funcsToConfigureAppLogger)
      .AddAppInfrastructureTiedToCore(logger);

    Guard.Against.Null(appConfigOptions.MongoDB);

    services.AddAppInfrastructureTiedToMongoDB(logger, appConfigOptions.MongoDB, appBuilder.Configuration);

    switch (appConfigOptions.MessageBroker)
    {
      case AppConfigOptionsMessageBrokerEnum.Kafka:
        Guard.Against.Null(appConfigOptions.Kafka);
        services.AddAppInfrastructureTiedToKafka(logger, appConfigOptions.Kafka);
        break;
      case AppConfigOptionsMessageBrokerEnum.RabbitMQ:
        Guard.Against.Null(appConfigOptions.RabbitMQ);
        services.AddAppInfrastructureTiedToRabbitMQ(logger, appConfigOptions.RabbitMQ);
        break;
      default:
        throw new NotImplementedException();
    }

    services
      .AddHostedService<AppService>()
      .TryAddAppDomainUseCasesStubs(logger);

    logger.LogInformation("Application is ready to build");

    return appBuilder.Build();
  }
}
