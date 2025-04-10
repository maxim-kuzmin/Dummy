namespace Makc.Dummy.Reader.DomainUseCases.App;

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
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppDomainUseCases(this IServiceCollection services, ILogger logger)
  {
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

    services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
    
    services.AddScoped<IDummyItemCommandService, DummyItemCommandService>();
    services.AddTransient<IDummyItemQueryService, DummyItemQueryService>();

    logger.LogInformation("Added application domain use cases");

    return services;
  }

  /// <summary>
  /// Попробовать добавить заглушки вариантов использования домена приложения.
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
