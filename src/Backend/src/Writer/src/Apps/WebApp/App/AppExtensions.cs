﻿namespace Makc.Dummy.Writer.Apps.WebApp.App;

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
  public static WebApplication BuildApp(this WebApplicationBuilder appBuilder, ILogger logger)
  {
    var appConfigSection = appBuilder.Configuration.GetSection("App");

    var appConfigAuthenticationSection = appConfigSection.GetSection("Authentication");

    var appConfigOptions = new AppConfigOptions();

    appConfigSection.Bind(appConfigOptions);

    Thread.CurrentThread.CurrentUICulture =
      Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(appConfigOptions.DefaultLanguage);

    var services = appBuilder.Services.Configure<AppConfigOptions>(appConfigSection)
      .AddAppDomainModel(logger)
      .AddAppDomainUseCases(logger, appConfigAuthenticationSection);

    List<AppLoggerFuncToConfigure> funcsToConfigureAppLogger = [];

    if (appConfigOptions.Observability != null)
    {
      services
        .AddAppSharedInfrastructureTiedToCoreForOpenTelemetryInWeb(
          logger,
          appConfigOptions.Observability,
          out var funcToConfigureMetrics,
          out var funcToConfigureTracing
        )
        .AddAppSharedInfrastructureTiedToCoreForOpenTelemetry(
          logger,
          appConfigOptions.Observability,
          funcToConfigureMetrics,
          funcToConfigureTracing,
          out var funcToConfigureAppLogger);

      if (funcToConfigureAppLogger != null)
      {
        funcsToConfigureAppLogger.Add(funcToConfigureAppLogger);
      }
    }

    services
      .AddAppSharedInfrastructureTiedToCore(logger, appBuilder.Configuration, funcsToConfigureAppLogger)
      .AddAppInfrastructureTiedToCore(logger)
      .AddAppInfrastructureTiedToDapper(logger, appConfigOptions.DbQueryORM);

    AppDbSQLSettings appDbSQLSettings;

    switch (appConfigOptions.Db)
    {
      case AppConfigOptionsDbEnum.MSSQLServer:
        services
          .AddAppInfrastructureTiedToMSSQLServer(logger, out appDbSQLSettings)          
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
        services
          .AddAppInfrastructureTiedToPostgreSQL(logger, out appDbSQLSettings)
          .AddAppInfrastructureTiedToEntityFrameworkForPostgreSQL(
            logger,
            appConfigOptions.PostgreSQL,
            appBuilder.Configuration)
          .AddAppInfrastructureTiedToDapperForPostgreSQL(
            logger,
            appConfigOptions.PostgreSQL,
            appBuilder.Configuration);
        break;
      default:
        throw new NotImplementedException();
    }

    services
      .AddAppInfrastructureTiedToEntityFramework(logger, appDbSQLSettings, appConfigOptions.DbQueryORM)
      .AddAppInfrastructureTiedToGrpc(logger)
      .AddAppInfrastructureTiedToRabbitMQ(logger, appConfigOptionsRabbitMQSection: null);

    services.Configure<CookiePolicyOptions>(options =>
    {
      options.CheckConsentNeeded = context => true;
      options.MinimumSameSitePolicy = SameSiteMode.None;
    });

    services.AddFastEndpoints();

    var authentication = Guard.Against.Null(appConfigOptions.Authentication);

    services
      .AddAuthorization()
      .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options =>
      {
        byte[] keyBytes = Encoding.UTF8.GetBytes(authentication.Key);

        var issuerSigningKey = authentication.GetSymmetricSecurityKey();

        options.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = true,
          ValidIssuer = authentication.Issuer,
          ValidateAudience = true,
          ValidAudience = authentication.Audience,
          ValidateLifetime = true,
          IssuerSigningKey = issuerSigningKey,
          ValidateIssuerSigningKey = true
        };
      });

    services.SwaggerDocument(options =>
    {
      options.ShortSchemaNames = true;
      options.EnableJWTBearerAuth = true;
    });

    logger.LogInformation("Application is ready to build");

    return appBuilder.Build();
  }

  /// <summary>
  /// Использовать приложение.
  /// </summary>
  /// <param name="app">Приложение.</param>
  /// <param name="logger">Логгер.</param>
  /// <returns>Приложение.</returns>
  public static async Task<WebApplication> UseApp(this WebApplication app, ILogger logger)
  {
    if (app.Environment.IsDevelopment())
    {
      IdentityModelEventSource.ShowPII = true;

      app.UseDeveloperExceptionPage();
    }
    else
    {
      app.UseDefaultExceptionHandler(); // from FastEndpoints

      app.UseHsts();
    }

    var appConfigOptionsMonitor = app.Services.GetRequiredService<IOptionsMonitor<AppConfigOptions>>();

    var appConfigOptions = appConfigOptionsMonitor.CurrentValue;

    var supportedCultures = appConfigOptions.Languages.Select(CultureInfo.GetCultureInfo).ToList();

    var requestLocalizationOptions = new RequestLocalizationOptions
    {
      DefaultRequestCulture = new(appConfigOptions.DefaultLanguage),
      SupportedCultures = supportedCultures,
      SupportedUICultures = supportedCultures
    };

    app.UseRequestLocalization(requestLocalizationOptions);

    //app.UseHttpsRedirection(); // //makc//Не нужно для внутреннего сервиса//

    app
      .UseAuthentication()
      .UseAuthorization()
      .UseMiddleware<AppTracingMiddleware>()
      .UseMiddleware<AppSessionMiddleware>();

    app.UseAppInfrastructureTiedToGrpc(logger);

    app.UseFastEndpoints().UseSwaggerGen(); // Includes AddFileServer and static files middleware

    await app.UseAppInfrastructureTiedToEntityFramework(logger);

    logger.LogInformation("Application is ready to run");

    return app;
  }
}
