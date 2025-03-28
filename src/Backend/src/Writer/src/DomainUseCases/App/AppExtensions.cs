﻿namespace Makc.Dummy.Writer.DomainUseCases.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить варианты использования домена приложения.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appConfigAuthenticationSection">Раздел аутентификации в конфигурации приложения.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppDomainUseCases(
    this IServiceCollection services,
    ILogger logger,
    IConfigurationSection? appConfigAuthenticationSection)
  {
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

    services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

    if (appConfigAuthenticationSection != null)
    {
      services.Configure<AppConfigOptionsAuthenticationSection>(appConfigAuthenticationSection);
    }

    services.AddTransient<IAppEventQueryService, AppEventQueryService>();

    services.AddTransient<IAppEventPayloadQueryService, AppEventPayloadQueryService>();

    services.AddScoped<IDummyItemCommandService, DummyItemCommandService>();    
    services.AddTransient<IDummyItemQueryService, DummyItemQueryService>();

    logger.LogInformation("Added application domain use cases");

    return services;
  }
}
