namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.App;

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
      services.Configure<AppConfigOptionsDomainAuthSection>(appConfigAuthenticationSection);
    }

    services.AddTransient<IAppOutboxCommandService, AppOutboxCommandService>();

    services.AddTransient<IAppOutgoingEventCommandService, AppOutgoingEventCommandService>();
    services.AddTransient<IAppOutgoingEventQueryService, AppOutgoingEventQueryService>();

    services.AddTransient<IAppOutgoingEventPayloadCommandService, AppOutgoingEventPayloadCommandService>();
    services.AddTransient<IAppOutgoingEventPayloadQueryService, AppOutgoingEventPayloadQueryService>();

    services.AddTransient<IAuthCommandService, AuthCommandService>();

    services.AddTransient<IDummyItemCommandService, DummyItemCommandService>();    
    services.AddTransient<IDummyItemQueryService, DummyItemQueryService>();

    logger.LogInformation("Added application domain use cases");

    return services;
  }

  /// <summary>
  /// Попробовать добавить заглушки вариантов использования предметной области приложения.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection TryAddAppDomainUseCasesStubs(
    this IServiceCollection services,
    ILogger logger)
  {
    services.TryAddTransient<IAppMessageProducer, AppMessageProducerStub>();

    logger.LogInformation("Tried to add application domain use cases stubs");

    return services;
  }
}
