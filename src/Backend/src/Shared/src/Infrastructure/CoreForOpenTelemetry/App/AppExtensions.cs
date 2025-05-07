namespace Makc.Dummy.Shared.Infrastructure.CoreForOpenTelemetry.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить разделяемую инфраструктуру приложения, привязанную к ядру для Open Telemetry.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appConfigOptions">Параметры конфигурации приложения.</param>
  /// <param name="funcToConfigureAppMetrics">Функция настройки измерений приложения.</param>
  /// <param name="funcToConfigureAppTracing">Функция настройки отслеживания приложения.</param>
  /// <param name="funcToConfigureAppLogger">Функция настройки логгера приложения.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppSharedInfrastructureTiedToCoreForOpenTelemetry(
    this IServiceCollection services,
    Microsoft.Extensions.Logging.ILogger logger,
    AppConfigOptionsInfrastructureObservabilitySection appConfigOptions,
    AppMetricsFuncToConfigure? funcToConfigureAppMetrics,
    AppTracingFuncToConfigure? funcToConfigureAppTracing,
    out AppLoggerFuncToConfigure? funcToConfigureAppLogger)
  {
    if (appConfigOptions.IsLogsCollectionEnabled)
    {
      funcToConfigureAppLogger = (serviceProvider, config) => config.AddAppLogsToOpenTelemetry(
          serviceProvider,
          appConfigOptions.CollectorGrpcEndpoint,
          appConfigOptions.ServiceName);
    }
    else
    {
      funcToConfigureAppLogger = null;
    }

    var openTelemetryBuilder = services.AddOpenTelemetry()
      .ConfigureResource(resource => resource.AddService(appConfigOptions.ServiceName));

    if (appConfigOptions.IsMetricsCollectionEnabled)
    {
      openTelemetryBuilder.AddAppMetricsToOpenTelemetry(
        appConfigOptions.CollectorGrpcEndpoint,
        funcToConfigureAppMetrics);
    }

    if (appConfigOptions.IsTracingCollectionEnabled)
    {
      openTelemetryBuilder.AddAppTracingToOpenTelemetry(
        appConfigOptions.CollectorGrpcEndpoint,
        funcToConfigureAppTracing);
    }

    logger.LogInformation("Added application shared infrastructure tied to Core for Open Telemetry");

    return services;
  }

  private static LoggerConfiguration AddAppLogsToOpenTelemetry(
    this LoggerConfiguration config,
    IServiceProvider serviceProvider,
    string collectorEndpoint,
    string serviceName)
  {
    config.ReadFrom.Services(serviceProvider)
      .Enrich.FromLogContext()
      .Enrich.WithProperty("ApplicationName", serviceName)
      .WriteTo.OpenTelemetry(options =>
      {
        options.Endpoint = collectorEndpoint;
        options.Protocol = OtlpProtocol.Grpc;
        options.IncludedData = IncludedData.TraceIdField | IncludedData.SpanIdField | IncludedData.SourceContextAttribute;
        options.ResourceAttributes = new Dictionary<string, object>
        {
              {"service.name", serviceName},
              {"index", 10},
              {"flag", true},
              {"value", 3.14}
        };
      });

    return config;
  }

  private static OpenTelemetryBuilder AddAppMetricsToOpenTelemetry(
    this OpenTelemetryBuilder builder,
    string collectorEndpoint,
    AppMetricsFuncToConfigure? funcToConfigureMetrics)
  {
    builder.WithMetrics(providerBuilder =>
    {
      providerBuilder.AddOtlpExporter(options =>
      {
        options.Endpoint = new Uri(collectorEndpoint);
        options.Protocol = OtlpExportProtocol.Grpc;
        options.ExportProcessorType = ExportProcessorType.Batch;
      });

      funcToConfigureMetrics?.Invoke(providerBuilder);
    });

    return builder;
  }

  private static OpenTelemetryBuilder AddAppTracingToOpenTelemetry(
    this OpenTelemetryBuilder builder,
    string collectorEndpoint,
    AppTracingFuncToConfigure? funcToConfigureTracing)
  {
    builder.WithTracing(providerBuilder =>
    {
      providerBuilder.SetErrorStatusOnException()
        .SetSampler(new AlwaysOnSampler())
        .AddOtlpExporter(options =>
        {
          options.Endpoint = new Uri(collectorEndpoint);
          options.Protocol = OtlpExportProtocol.Grpc;
          options.ExportProcessorType = ExportProcessorType.Batch;
        });

      funcToConfigureTracing?.Invoke(providerBuilder);
    });

    return builder;
  }
}
