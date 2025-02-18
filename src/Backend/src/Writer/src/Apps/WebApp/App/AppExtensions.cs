namespace Makc.Dummy.Writer.Apps.WebApp.App;

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

    var appConfigSectionAuthentication = appConfigSection.GetSection("Authentication");

    var appConfigSectionRabbitMQ = appConfigSection.GetSection("RabbitMQ");

    var appConfigOptions = new AppConfigOptions();

    appConfigSection.Bind(appConfigOptions);

    Thread.CurrentThread.CurrentUICulture =
      Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(appConfigOptions.DefaultLanguage);

    var services = appBuilder.Services.Configure<AppConfigOptions>(appConfigSection)
      .AddAppDomainModel(logger)
      .AddAppDomainUseCases(logger)
      .AddAppInfrastructureTiedToCore(logger, appBuilder.Configuration, appConfigSectionAuthentication)
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
      .AddAppInfrastructureTiedToGrpc(logger)
      .AddAppInfrastructureTiedToRabbitMQ(logger, appConfigSectionRabbitMQ);

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

    //app.UseHttpsRedirection(); // //qwer//Не нужно для внутреннего сервиса//

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
