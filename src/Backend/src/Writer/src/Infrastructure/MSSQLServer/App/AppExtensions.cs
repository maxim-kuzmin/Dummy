using Makc.Dummy.Writer.DomainUseCases.DummyItem;
using Makc.Dummy.Writer.Infrastructure.MSSQLServer.DummyItem;

namespace Makc.Dummy.Writer.Infrastructure.MSSQLServer.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к базе данных MS SQL Server.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appDbSettings">Настройки базы данных приложения.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToMSSQLServer(
    this IServiceCollection services,
    ILogger logger,
    out AppDbSettingsBase appDbSettings)
  {
    appDbSettings = new AppDbSettings();

    services.AddSingleton((AppDbSettings)appDbSettings);

    services.AddSingleton(appDbSettings.Entities.AppEvent);
    services.AddSingleton<AppEventEntitySettings>(appDbSettings.Entities.AppEvent);
    services.AddSingleton<IAppEventGetActionFactory, AppEventGetActionFactory>();
    services.AddSingleton<IAppEventGetListActionFactory, AppEventGetListActionFactory>();

    services.AddSingleton(appDbSettings.Entities.AppEventPayload);
    services.AddSingleton<AppEventPayloadEntitySettings>(appDbSettings.Entities.AppEventPayload);
    services.AddSingleton<IAppEventPayloadGetActionFactory, AppEventPayloadGetActionFactory>();
    services.AddSingleton<IAppEventPayloadGetListActionFactory, AppEventPayloadGetListActionFactory>();

    services.AddSingleton(appDbSettings.Entities.DummyItem);
    services.AddSingleton<DummyItemEntitySettings>(appDbSettings.Entities.DummyItem);
    services.AddSingleton<IDummyItemFactory, DummyItemFactory>();

    logger.LogInformation("Added application infrastructure tied to MS SQL Server");

    return services;
  }
}
