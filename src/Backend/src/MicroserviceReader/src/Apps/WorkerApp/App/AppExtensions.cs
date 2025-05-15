namespace Makc.Dummy.MicroserviceReader.Apps.WorkerApp.App;

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

    bool isMeassageBrokerEnabled = false;

    var workloads = appConfigOptions.Workloads ?? throw new Exception($"Workloads are null");

    if (workloads.Length == 0)
    {
      throw new Exception($"Workloads are empty");
    }

    foreach (var workload in workloads)
    {
      switch (workload)
      {
        case AppConfigOptionsWorkloadEnum.AppInboxCleaner:
          services.AddHostedService<AppInboxCleanerService>();
          break;
        case AppConfigOptionsWorkloadEnum.AppInboxConsumer:
          isMeassageBrokerEnabled = true;
          services.AddHostedService<AppInboxConsumerService>();
          break;
        default:
          throw new NotImplementedException($"Unknown Workload: {workload}");
      }
    }

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

    if (isMeassageBrokerEnabled)
    {
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
    }

    services.TryAddAppDomainUseCasesStubs(logger);

    logger.LogInformation("Application is ready to build");

    return appBuilder.Build();
  }
}
