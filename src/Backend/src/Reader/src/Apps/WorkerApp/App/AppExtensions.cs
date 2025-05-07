namespace Makc.Dummy.Reader.Apps.WorkerApp.App;

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

    var domain = Guard.Against.Null(appConfigOptions.Domain);
    var domainApp = Guard.Against.Null(domain.App);
    var infrastructure = Guard.Against.Null(appConfigOptions.Infrastructure);

    List<AppLoggerFuncToConfigure> funcsToConfigureAppLogger = [];

    if (infrastructure.Observability != null)
    {
      services
        .AddAppSharedInfrastructureTiedToCoreForOpenTelemetry(
          logger,
          infrastructure.Observability,
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

    Guard.Against.Null(infrastructure.MongoDB);

    services.AddAppInfrastructureTiedToMongoDB(logger, infrastructure.MongoDB, appBuilder.Configuration, out _);

    switch (domainApp.MessageBroker)
    {
      case AppConfigOptionsMessageBrokerEnum.Kafka:
        Guard.Against.Null(infrastructure.Kafka);
        services.AddAppInfrastructureTiedToKafka(logger, infrastructure.Kafka);
        break;
      case AppConfigOptionsMessageBrokerEnum.RabbitMQ:
        Guard.Against.Null(infrastructure.RabbitMQ);
        services.AddAppInfrastructureTiedToRabbitMQ(logger, infrastructure.RabbitMQ);
        break;
      default:
        throw new NotImplementedException();
    }

    if (domain.AppInbox?.Cleaner?.IsEnabled == true)
    {
      services.AddHostedService<AppInboxCleanerService>();
    }

    if (domain.AppInbox?.Consumer?.IsEnabled == true)
    {
      services.AddHostedService<AppInboxConsumerService>();
    }

    services.TryAddAppDomainUseCasesStubs(logger);

    logger.LogInformation("Application is ready to build");

    return appBuilder.Build();
  }
}
