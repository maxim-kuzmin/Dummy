namespace Makc.Dummy.Writer.Infrastructure.PostgreSQL.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к базе данных PostgreSQL.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appDbSettings">Настройки базы данных приложения.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToPostgreSQL(
    this IServiceCollection services,
    ILogger logger,
    out AppDbSettingsBase appDbSettings)
  {
    appDbSettings = new AppDbSettings();

    services.AddSingleton((AppDbSettings)appDbSettings);

    services.AddSingleton(appDbSettings.Entities.AppEvent);
    services.AddSingleton<AppEventEntitySettings>(appDbSettings.Entities.AppEvent);
    services.AddSingleton<IAppEventFactory, AppEventFactory>();

    services.AddSingleton(appDbSettings.Entities.AppEventPayload);
    services.AddSingleton<AppEventPayloadEntitySettings>(appDbSettings.Entities.AppEventPayload);
    services.AddSingleton<IAppEventPayloadFactory, AppEventPayloadFactory>();

    services.AddSingleton(appDbSettings.Entities.DummyItem);
    services.AddSingleton<DummyItemEntitySettings>(appDbSettings.Entities.DummyItem);
    services.AddSingleton<IDummyItemFactory, DummyItemFactory>();

    logger.LogInformation("Added application infrastructure tied to PostgreSQL");

    return services;
  }
}
