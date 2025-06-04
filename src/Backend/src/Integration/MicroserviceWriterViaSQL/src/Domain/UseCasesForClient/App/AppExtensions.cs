namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCasesForClient.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить варианты использования предметной области для клиента интеграции микросервиса "Писатель" приложения.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppIntegrationMicroserviceWriterViaSQLDomainUseCasesForClient(
    this IServiceCollection services,
    ILogger logger)
  {
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

    services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

    logger.LogInformation("Added application integration microservice Writer domain use cases for client");

    return services;
  }

  /// <summary>
  /// Попробовать добавить заглушки вариантов использования предметной области для клиента интеграции
  /// микросервиса "Писатель" приложения.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection TryAddAppIntegrationMicroserviceWriterViaSQLDomainUseCasesForClientStubs(
    this IServiceCollection services,
    ILogger logger)
  {
    services.TryAddTransient<IAuthCommandService, AuthCommandServiceStub>();

    logger.LogInformation("Tried to add application integration microservice Writer domain use cases for client stubs");

    return services;
  }
}
