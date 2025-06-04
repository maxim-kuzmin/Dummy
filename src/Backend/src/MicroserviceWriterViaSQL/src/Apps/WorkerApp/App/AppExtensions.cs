namespace Makc.Dummy.MicroserviceWriterViaSQL.Apps.WorkerApp.App;

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

    var domain = Guard.Against.Null(appConfigOptions.Domain);
    var domainApp = Guard.Against.Null(domain.App);
    var infrastructure = Guard.Against.Null(appConfigOptions.Infrastructure);
    var workloads = Guard.Against.NullOrEmpty(appConfigOptions.Workloads);

    Thread.CurrentThread.CurrentUICulture =
      Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(appConfigOptions.DefaultLanguage);

    var services = appBuilder.Services.Configure<AppConfigOptions>(appConfigSection)
      .AddAppDomainModel(logger)
      .AddAppDomainUseCases(logger, appConfigDomainAuthSection: null);

    bool isMeassageBrokerEnabled = false;

    foreach (var workload in workloads)
    {
      switch (workload)
      {
        case AppConfigOptionsWorkloadEnum.AppDbMigration:
          services.AddHostedService<AppDbMigrationService>();
          break;
        case AppConfigOptionsWorkloadEnum.AppOutboxCleaner:
          services.AddHostedService<AppOutboxCleanerService>();
          break;
        case AppConfigOptionsWorkloadEnum.AppOutboxProducer:
          isMeassageBrokerEnabled = true;
          services.AddHostedService<AppOutboxProducerService>();
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
      .AddAppInfrastructureTiedToCore(logger)
      .AddAppInfrastructureTiedToDapper(logger, domainApp.DbQueryORM);

    AppDbSQLSettings appDbSQLSettings;

    switch (domainApp.Db)
    {
      case AppConfigOptionsDbEnum.MSSQLServer:
        Guard.Against.Null(infrastructure.MSSQLServer);
        services
          .AddAppInfrastructureTiedToMSSQLServer(logger, out appDbSQLSettings)
          .AddAppInfrastructureTiedToEntityFrameworkForMSSQLServer(
            logger,
            infrastructure.MSSQLServer,
            appBuilder.Configuration)
          .AddAppInfrastructureTiedToDapperForMSSQLServer(
            logger,
            infrastructure.MSSQLServer,
            appBuilder.Configuration);
        break;
      case AppConfigOptionsDbEnum.PostgreSQL:
        Guard.Against.Null(infrastructure.PostgreSQL);
        services
          .AddAppInfrastructureTiedToPostgreSQL(logger, out appDbSQLSettings)
          .AddAppInfrastructureTiedToEntityFrameworkForPostgreSQL(
            logger,
            infrastructure.PostgreSQL,
            appBuilder.Configuration)
          .AddAppInfrastructureTiedToDapperForPostgreSQL(
            logger,
            infrastructure.PostgreSQL,
            appBuilder.Configuration);
        break;
      default:
        throw new NotImplementedException($"Unknown Domain App {nameof(domainApp.Db)}: {domainApp.Db}");
    }

    services.AddAppInfrastructureTiedToEntityFramework(logger, appDbSQLSettings, domainApp.DbQueryORM);

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
          throw new NotImplementedException($"Unknown Domain App {nameof(domainApp.MessageBroker)}: {domainApp.MessageBroker}");
      }
    }

    services.TryAddAppDomainUseCasesStubs(logger);

    logger.LogInformation("Application is ready to build");

    return appBuilder.Build();
  }
}
