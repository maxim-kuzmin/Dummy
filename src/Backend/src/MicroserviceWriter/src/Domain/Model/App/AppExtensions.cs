namespace Makc.Dummy.MicroserviceWriter.Domain.Model.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить модель домена приложения.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppDomainModel(this IServiceCollection services, ILogger logger)
  {
    services.AddSingleton<IAppOutgoingEventFactory, AppOutgoingEventFactory>();

    services.AddSingleton<IAppOutgoingEventPayloadFactory, AppOutgoingEventPayloadFactory>();
    
    services.AddSingleton<IDummyItemFactory, DummyItemFactory>();

    logger.LogInformation("Added application domain model");

    return services;
  }
}
