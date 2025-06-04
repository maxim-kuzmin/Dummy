namespace Makc.Dummy.MicroserviceWriterViaSQL.Infrastructure.Core.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к ядру.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>  
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToCore(
    this IServiceCollection services,
    ILogger logger)
  {
    services.AddTransient<IAppOutgoingEventResources, AppOutgoingEventResources>();

    services.AddTransient<IAppOutgoingEventPayloadResources, AppOutgoingEventPayloadResources>();

    services.AddTransient<IDummyItemResources, DummyItemResources>();

    logger.LogInformation("Added application infrastructure tied to Core");

    return services;
  }
}
