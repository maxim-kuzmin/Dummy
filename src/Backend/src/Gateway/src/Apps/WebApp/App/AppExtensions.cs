namespace Makc.Dummy.Gateway.Apps.WebApp.App;

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

    var appConfigInfrastructureKeycloakSection = appConfigSection.GetSection("Infrastructure:Keycloak");

    var appConfigOptions = new AppConfigOptions();

    appConfigSection.Bind(appConfigOptions);

    Thread.CurrentThread.CurrentUICulture =
      Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(appConfigOptions.DefaultLanguage);

    var services = appBuilder.Services.Configure<AppConfigOptions>(appConfigSection)
      .AddAppDomainModel(logger)
      .AddAppDomainUseCases(logger, appConfigDomainAuthSection)
      .AddAppIntegrationMicroserviceReaderDomainUseCases(logger)
      .AddAppIntegrationMicroserviceWriterDomainUseCases(logger);

    var domain = Guard.Against.Null(appConfigOptions.Domain);
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
      .AddAppInfrastructureTiedToCore(logger);

    var domainAuth = Guard.Against.Null(domain.Auth);
    var integrationMicroserviceReader = Guard.Against.Null(appConfigOptions.Integration?.MicroserviceReader);
    var integrationMicroserviceWriter = Guard.Against.Null(appConfigOptions.Integration?.MicroserviceWriter);

    switch (integrationMicroserviceWriter.Protocol)
    {
      case AppConfigOptionsProtocolEnum.Http:
        services.AddAppIntegrationMicroserviceReaderInfrastructureTiedToHttpClient(
          logger,
          integrationMicroserviceReader.HttpEndpoint);
        services.AddAppIntegrationMicroserviceWriterInfrastructureTiedToHttpClient(
          logger,
          domainAuth,
          integrationMicroserviceWriter.HttpEndpoint);
        break;
      case AppConfigOptionsProtocolEnum.Grpc:
        services.AddAppIntegrationMicroserviceReaderInfrastructureTiedToGrpcClient(
          logger,
          integrationMicroserviceReader.GrpcEndpoint);
        services.AddAppIntegrationMicroserviceWriterInfrastructureTiedToGrpcClient(
          logger,
          domainAuth,
          integrationMicroserviceWriter.GrpcEndpoint);
        break;
      default:
        throw new NotImplementedException();
    }

    if (domainAuth.Type == AppConfigOptionsAuthenticationEnum.Keycloak)
    {
      Guard.Against.Null(appConfigInfrastructureKeycloakSection);

      Guard.Against.Null(infrastructure.Keycloak);

      string keycloakEndpoint = Guard.Against.Null(infrastructure.Keycloak.BaseUrl);

      services.AddAppInfrastructureTiedToHttpForKeycloak(
        logger,
        appConfigInfrastructureKeycloakSection,
        keycloakEndpoint);
    }

    services.Configure<CookiePolicyOptions>(options =>
    {
      options.CheckConsentNeeded = context => true;
      options.MinimumSameSitePolicy = SameSiteMode.None;
    });

    services
      .AddFastEndpoints(options =>
      {
        options.DisableAutoDiscovery = true;
        options.Assemblies = [
          typeof(Integration.MicroserviceReader.Infrastructure.HttpServer.App.AppSettings).Assembly,
          typeof(Integration.MicroserviceWriter.Infrastructure.HttpServer.App.AppSettings).Assembly
          ];
      })
      .AddAuthorization();

    switch (domainAuth.Type)
    {
      case AppConfigOptionsAuthenticationEnum.JWT:
        services
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
        break;
      case AppConfigOptionsAuthenticationEnum.Keycloak:
        services
          .AddAuthentication(options =>
          {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
          })
          .AddJwtBearer(options =>
          {
            Guard.Against.Null(infrastructure.Keycloak);

            string rootUrl = $"{infrastructure.Keycloak.BaseUrl}/realms/{infrastructure.Keycloak.Realm}";

            options.TokenValidationParameters = new TokenValidationParameters
            {
              ValidateIssuer = true,
              ValidIssuer = rootUrl.Replace("host.docker.internal", "localhost"),

              ValidateAudience = true,
              ValidAudience = "account",

              ValidateIssuerSigningKey = true,
              ValidateLifetime = false,

              IssuerSigningKeyResolver = (token, securityToken, kid, parameters) =>
              {
                var client = new HttpClient();
                var keyUri = $"{rootUrl}/protocol/openid-connect/certs";
                var response = client.GetAsync(keyUri).Result;
                var keys = new JsonWebKeySet(response.Content.ReadAsStringAsync().Result);

                return keys.GetSigningKeys();
              },

              NameClaimType = "preferred_username",
              RoleClaimType = "roles"
            };

            options.RequireHttpsMetadata = false; // //makc//!!!// Only in develop environment
            options.SaveToken = true;
          });
        break;
      default:
        throw new NotImplementedException();
    }

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

    app.UseHttpsRedirection();

    app
      .UseAuthentication()
      .UseAuthorization()
      .UseMiddleware<AppTracingMiddleware>()
      .UseMiddleware<AppSessionMiddleware>();

    app.UseFastEndpoints().UseSwaggerGen(); // Includes AddFileServer and static files middleware    

    logger.LogInformation("Application is ready to run");

    return app;
  }
}
