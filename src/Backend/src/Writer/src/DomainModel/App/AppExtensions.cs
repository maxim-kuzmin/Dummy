namespace Makc.Dummy.Writer.DomainModel.App;

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
    services.AddSingleton<IAppEventFactory, AppEventFactory>();

    services.AddSingleton<IAppEventPayloadFactory, AppEventPayloadFactory>();
    
    services.AddSingleton<IDummyItemFactory, DummyItemFactory>();

    logger.LogInformation("Added application domain model");

    return services;
  }
}
