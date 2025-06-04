using Microsoft.Extensions.DependencyInjection;

namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Apps.WorkerApp.App;

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
    var integration = Guard.Against.Null(appConfigOptions.Integration);
    var integrationMicroserviceWriterViaSQL = Guard.Against.Null(integration.MicroserviceWriterViaSQL);
    var workloads = Guard.Against.NullOrEmpty(appConfigOptions.Workloads);

    Thread.CurrentThread.CurrentUICulture =
      Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(appConfigOptions.DefaultLanguage);

    var services = appBuilder.Services.Configure<AppConfigOptions>(appConfigSection)
      .AddAppDomainModel(logger)
      .AddAppDomainUseCases(logger, appConfigDomainAuthSection: null)
      .AddAppIntegrationMicroserviceWriterViaSQLDomainUseCasesForClient(logger);

    switch (integrationMicroserviceWriterViaSQL.Protocol)
    {
      case AppConfigOptionsProtocolEnum.Http:
        services.AddAppIntegrationMicroserviceWriterViaSQLInfrastructureTiedToHttpClient(
          logger,
          domainAuthSection: null,
          integrationMicroserviceWriterViaSQL.HttpEndpoint);
        break;
      case AppConfigOptionsProtocolEnum.Grpc:
        services.AddAppIntegrationMicroserviceWriterViaSQLInfrastructureTiedToGrpcClient(
          logger,
          domainAuthSection: null,
          integrationMicroserviceWriterViaSQL.GrpcEndpoint);        
        break;
      default:
        throw new NotImplementedException();
    }

    bool isMeassageBrokerEnabled = false;

    foreach (var workload in workloads)
    {
      switch (workload)
      {
        case AppConfigOptionsWorkloadEnum.AppInboxCleaner:
          services.AddHostedService<AppInboxCleanerService>();
          break;
        case AppConfigOptionsWorkloadEnum.AppInboxConsumer:
          {
            isMeassageBrokerEnabled = true;

            var eventNames = Guard.Against.NullOrEmpty(domain.AppInbox?.Consumer?.EventNames);
            
            foreach (var eventName in eventNames)
            {
              services.AddHostedService(x => new AppInboxConsumerService(
                eventName,
                x.GetRequiredService<IAppMessageBroker>(),
                x.GetRequiredService<IAppMessageConsumer>(),
                x.GetRequiredService<ILogger<AppInboxConsumerService>>(),
                x.GetRequiredService<IServiceScopeFactory>()));
            }
          }
          break;
        case AppConfigOptionsWorkloadEnum.AppInboxLoader:
          {
            var eventNames = Guard.Against.NullOrEmpty(domain.AppInbox?.Loader?.EventNames);

            foreach (var eventName in eventNames)
            {
              services.AddHostedService(x => new AppInboxLoaderService(
                eventName,
                x.GetRequiredService<ILogger<AppInboxLoaderService>>(),
                x.GetRequiredService<IServiceScopeFactory>()));
            }
          }
          break;
        case AppConfigOptionsWorkloadEnum.AppInboxProcessor:
          {
            var eventNames = Guard.Against.NullOrEmpty(domain.AppInbox?.Processor?.EventNames);

            foreach (var eventName in eventNames)
            {
              services.AddHostedService(x => new AppInboxProcessorService(
                eventName,
                x.GetRequiredService<ILogger<AppInboxProcessorService>>(),
                x.GetRequiredService<IServiceScopeFactory>()));
            }
          }
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

    services
      .TryAddAppDomainUseCasesStubs(logger)
      .TryAddAppIntegrationMicroserviceWriterViaSQLDomainUseCasesForClientStubs(logger);

    logger.LogInformation("Application is ready to build");

    return appBuilder.Build();
  }
}
