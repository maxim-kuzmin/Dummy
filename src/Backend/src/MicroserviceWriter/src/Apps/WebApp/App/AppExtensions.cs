namespace Makc.Dummy.MicroserviceWriter.Apps.WebApp.App;

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

    var appConfigDomainAuthSection = appConfigSection.GetSection("Domain:Auth");

    var appConfigOptions = new AppConfigOptions();

    appConfigSection.Bind(appConfigOptions);

    Thread.CurrentThread.CurrentUICulture =
      Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(appConfigOptions.DefaultLanguage);

    var services = appBuilder.Services.Configure<AppConfigOptions>(appConfigSection)
      .AddAppDomainModel(logger)
      .AddAppDomainUseCases(logger, appConfigDomainAuthSection);

    var domain = Guard.Against.Null(appConfigOptions.Domain);
    var domainApp = Guard.Against.Null(domain.App);
    var infrastructure = Guard.Against.Null(appConfigOptions.Infrastructure);

    List<AppLoggerFuncToConfigure> funcsToConfigureAppLogger = [];

    if (infrastructure.Observability != null)
    {
      services
        .AddAppSharedInfrastructureTiedToCoreForOpenTelemetryInWeb(
          logger,
          infrastructure.Observability,
          out var funcToConfigureMetrics,
          out var funcToConfigureTracing
        )
        .AddAppSharedInfrastructureTiedToCoreForOpenTelemetry(
          logger,
          infrastructure.Observability,
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
      .AddAppInfrastructureTiedToDapper(logger, domainApp.DbQueryORM);

    AppDbSQLSettings appDbSQLSettings;

    switch (domainApp.Db)
    {
      case AppConfigOptionsDbEnum.MSSQLServer:
        Guard.Against.Null(infrastructure.MSSQLServer);
        services
          .AddAppInfrastructureTiedToMSSQLServer(logger, out appDbSQLSettings)          
          .AddAppInfrastructureTiedToEntityFrameworkForMSSQLServer(
            logger,
            infrastructure.MSSQLServer,
            appBuilder.Configuration)
          .AddAppInfrastructureTiedToDapperForMSSQLServer(
            logger,
            infrastructure.MSSQLServer,
            appBuilder.Configuration);
        break;
      case AppConfigOptionsDbEnum.PostgreSQL:
        Guard.Against.Null(infrastructure.PostgreSQL);
        services
          .AddAppInfrastructureTiedToPostgreSQL(logger, out appDbSQLSettings)
          .AddAppInfrastructureTiedToEntityFrameworkForPostgreSQL(
            logger,
            infrastructure.PostgreSQL,
            appBuilder.Configuration)
          .AddAppInfrastructureTiedToDapperForPostgreSQL(
            logger,
            infrastructure.PostgreSQL,
            appBuilder.Configuration);
        break;
      default:
        throw new NotImplementedException();
    }

    services
      .AddAppInfrastructureTiedToEntityFramework(logger, appDbSQLSettings, domainApp.DbQueryORM)
      .AddAppInfrastructureTiedToGrpc(logger)
      .TryAddAppDomainUseCasesStubs(logger);

    services.Configure<CookiePolicyOptions>(options =>
    {
      options.CheckConsentNeeded = context => true;
      options.MinimumSameSitePolicy = SameSiteMode.None;
    });

    services.AddFastEndpoints(options => {
      options.DisableAutoDiscovery = true; options.DisableAutoDiscovery = true;
      options.Assemblies = [
        typeof(Infrastructure.Web.DummyItem.Endpoints.DummyItemEndpointsSettings).Assembly,
        ];      
    });

    var domainAuth = Guard.Against.Null(domain.Auth);

    services
      .AddAuthorization()
      .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options =>
      {
        byte[] keyBytes = Encoding.UTF8.GetBytes(domainAuth.Key);

        var issuerSigningKey = domainAuth.GetSymmetricSecurityKey();

        options.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = true,
          ValidIssuer = domainAuth.Issuer,
          ValidateAudience = true,
          ValidAudience = domainAuth.Audience,
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
  public static WebApplication UseApp(this WebApplication app, ILogger logger)
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

    logger.LogInformation("Application is ready to run");

    return app;
  }
}
