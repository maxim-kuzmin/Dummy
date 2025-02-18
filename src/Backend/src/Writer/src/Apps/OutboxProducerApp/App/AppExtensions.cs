﻿namespace Makc.Dummy.Writer.Apps.OutboxProducerApp.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Построить приложение.
  /// </summary>
  /// <param name="appBuilder">Построитель приложения.</param>
  /// <param name="logger">Логгер.</param>
  /// <returns>Приложение.</returns>
  public static IHost BuildApp(this HostApplicationBuilder appBuilder, ILogger logger)
  {
    var appConfigSection = appBuilder.Configuration.GetSection("App");

    var appConfigSectionRabbitMQ = appConfigSection.GetSection("RabbitMQ");

    var appConfigOptions = new AppConfigOptions();

    appConfigSection.Bind(appConfigOptions);

    Thread.CurrentThread.CurrentUICulture =
      Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(appConfigOptions.DefaultLanguage);

    var services = appBuilder.Services.Configure<AppConfigOptions>(appConfigSection)
      .AddAppDomainModel(logger)
      .AddAppDomainUseCases(logger)
      .AddAppInfrastructureTiedToCore(logger, appBuilder.Configuration)
      .AddAppInfrastructureTiedToDapper(logger, appConfigOptions.ActionQueryORM);

    AppDbSettings appDbSettings;

    switch (appConfigOptions.Db)
    {
      case AppConfigOptionsDbEnum.MSSQLServer:
        services
          .AddAppInfrastructureTiedToMSSQLServer(logger, out appDbSettings)
          .AddAppInfrastructureTiedToEntityFrameworkForMSSQLServer(
            logger,
            appConfigOptions.MSSQLServer,
            appBuilder.Configuration)
          .AddAppInfrastructureTiedToDapperForMSSQLServer(
            logger,
            appConfigOptions.MSSQLServer,
            appBuilder.Configuration);
        break;
      case AppConfigOptionsDbEnum.PostgreSQL:
      default:
        services
          .AddAppInfrastructureTiedToPostgreSQL(logger, out appDbSettings)
          .AddAppInfrastructureTiedToEntityFrameworkForPostgreSQL(
            logger,
            appConfigOptions.PostgreSQL,
            appBuilder.Configuration)
          .AddAppInfrastructureTiedToDapperForPostgreSQL(
            logger,
            appConfigOptions.PostgreSQL,
            appBuilder.Configuration);
        break;
    }

    services
      .AddAppInfrastructureTiedToEntityFramework(logger, appDbSettings, appConfigOptions.ActionQueryORM)
      .AddAppInfrastructureTiedToRabbitMQ(logger, appConfigSectionRabbitMQ);

    services.AddHostedService<AppService>();

    logger.LogInformation("Application is ready to build");

    return appBuilder.Build();
  }
}
