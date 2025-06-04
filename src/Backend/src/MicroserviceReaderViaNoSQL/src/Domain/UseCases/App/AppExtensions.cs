namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.App;

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

    services.AddTransient<IAppInboxCommandService, AppInboxCommandService>();

    services.AddTransient<IAppIncomingEventCommandService, AppIncomingEventCommandService>();
    services.AddTransient<IAppIncomingEventQueryService, AppIncomingEventQueryService>();

    services.AddTransient<IAppIncomingEventPayloadCommandService, AppIncomingEventPayloadCommandService>();
    services.AddTransient<IAppIncomingEventPayloadQueryService, AppIncomingEventPayloadQueryService>();

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
    services.TryAddTransient<IAppMessageConsumer, AppMessageConsumerStub>();

    logger.LogInformation("Tried to add application domain use cases stubs");

    return services;
  }
}
