namespace Makc.Dummy.MicroserviceWriterViaSQL.Infrastructure.PostgreSQL.App;

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
  /// <param name="appDbSQLSettings">Настройки базы данных SQL приложения.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToPostgreSQL(
    this IServiceCollection services,
    ILogger logger,
    out AppDbSQLSettings appDbSQLSettings)
  {
    appDbSQLSettings = new AppDbSettings();

    services.AddSingleton((AppDbSettings)appDbSQLSettings);

    services.AddSingleton<IAppDbSQLCommandHelper, AppDbCommandHelper>();

    services.AddSingleton(appDbSQLSettings.Entities.AppOutgoingEvent);
    services.AddSingleton<AppOutgoingEventEntitySettings>(appDbSQLSettings.Entities.AppOutgoingEvent);
    services.AddSingleton<IAppOutgoingEventDbSQLCommandFactory, AppOutgoingEventDbCommandFactory>();

    services.AddSingleton(appDbSQLSettings.Entities.AppOutgoingEventPayload);
    services.AddSingleton<AppOutgoingEventPayloadEntitySettings>(appDbSQLSettings.Entities.AppOutgoingEventPayload);
    services.AddSingleton<IAppOutgoingEventPayloadDbSQLCommandFactory, AppOutgoingEventPayloadDbCommandFactory>();

    services.AddSingleton(appDbSQLSettings.Entities.DummyItem);
    services.AddSingleton<DummyItemEntitySettings>(appDbSQLSettings.Entities.DummyItem);
    services.AddSingleton<IDummyItemDbSQLCommandFactory, DummyItemDbCommandFactory>();

    logger.LogInformation("Added application infrastructure tied to PostgreSQL");

    return services;
  }
}
