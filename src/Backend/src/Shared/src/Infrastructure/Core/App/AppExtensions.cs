namespace Makc.Dummy.Shared.Infrastructure.Core.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить разделяемую инфраструктуру приложения, привязанную к ядру.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="configuration">Конфигурация.</param>
  /// <param name="funcsToConfigureAppLogger">Функции настройки логгера приложения.</param>  
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppSharedInfrastructureTiedToCore(
    this IServiceCollection services,
    Microsoft.Extensions.Logging.ILogger logger,
    IConfiguration configuration,
    List<AppLoggerFuncToConfigure> funcsToConfigureAppLogger)
  {
    services.AddSerilog((serviceProvider, config) =>
    {
      config.ReadFrom.Configuration(configuration);

      foreach (var funcToConfigureAppLogger in funcsToConfigureAppLogger)
      {
        funcToConfigureAppLogger.Invoke(serviceProvider, config);
      }
    });

    services.AddJsonLocalization();

    services.AddScoped<AppSession>();

    logger.LogInformation("Added application shared infrastructure tied to Core");

    return services;
  }
}
