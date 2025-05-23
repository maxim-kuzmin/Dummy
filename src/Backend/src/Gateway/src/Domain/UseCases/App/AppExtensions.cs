namespace Makc.Dummy.Gateway.Domain.UseCases.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить варианты использования предметной области приложения.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appConfigDomainAuthSection">
  /// Раздел аутентификации в конфигурации предметной области приложения.
  /// </param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppDomainUseCases(
    this IServiceCollection services,
    ILogger logger,
    IConfigurationSection? appConfigDomainAuthSection)
  {
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

    services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

    if (appConfigDomainAuthSection != null)
    {
      services.Configure<AppConfigOptionsDomainAuthSection>(appConfigDomainAuthSection);
    }

    logger.LogInformation("Added application domain use cases");

    return services;
  }
}
