namespace Makc.Dummy.Shared.Infrastructure.CoreForOpenTelemetryInWeb.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить разделяемую инфраструктуру приложения, привязанную к ядру для Open Telemetry в Web.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appConfigOptions">Параметры конфигурации приложения.</param>
  /// <param name="funcToConfigureAppMetrics">Функция настройки измерений приложения.</param>
  /// <param name="funcToConfigureAppTracing">Функция настройки отслеживания приложения.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppSharedInfrastructureTiedToCoreForOpenTelemetryInWeb(
    this IServiceCollection services,
    ILogger logger,
    AppConfigOptionsInfrastructureObservabilitySection appConfigOptions,
    out AppMetricsFuncToConfigure? funcToConfigureAppMetrics,
    out AppTracingFuncToConfigure? funcToConfigureAppTracing)
  {
    if (appConfigOptions.IsMetricsCollectionEnabled)
    {
      funcToConfigureAppMetrics = (providerBuilder) => providerBuilder.AddAspNetCoreInstrumentation();
    }
    else
    {
      funcToConfigureAppMetrics = null;
    }

    if (appConfigOptions.IsTracingCollectionEnabled)
    {
      funcToConfigureAppTracing = (providerBuilder) => providerBuilder.AddAspNetCoreInstrumentation(options =>
        {
          options.RecordException = true;
        });
    }
    else
    {
      funcToConfigureAppTracing = null;
    }

    logger.LogInformation("Added application shared infrastructure tied to Core for Open Telemetry in Web");

    return services;
  }
}
