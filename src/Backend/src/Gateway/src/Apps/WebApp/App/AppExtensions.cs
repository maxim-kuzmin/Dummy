﻿namespace Makc.Dummy.Gateway.Apps.WebApp.App;

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

    var appConfigKeycloakSection = appConfigSection.GetSection("Keycloak");

    var appConfigOptions = new AppConfigOptions();

    appConfigSection.Bind(appConfigOptions);

    Thread.CurrentThread.CurrentUICulture =
      Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(appConfigOptions.DefaultLanguage);

    var services = appBuilder.Services.Configure<AppConfigOptions>(appConfigSection)
      .AddAppDomainModel(logger)
      .AddAppDomainUseCases(
        logger,
        appConfigAuthenticationSection,
        appConfigKeycloakSection,
        appConfigOptions.Keycloak?.BaseUrl);

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
      .AddAppInfrastructureTiedToCore(logger);

    var writer = Guard.Against.Null(appConfigOptions.Writer);

    switch (writer.Protocol)
    {
      case AppConfigOptionsProtocolEnum.Http:
        services.AddAppInfrastructureTiedToHttp(logger, writer.HttpEndpoint);
        break;
      case AppConfigOptionsProtocolEnum.Grpc:
        services.AddAppInfrastructureTiedToGrpc(logger, writer.GrpcEndpoint);
        break;
      default:
        throw new NotImplementedException();
    }

    services.Configure<CookiePolicyOptions>(options =>
    {
      options.CheckConsentNeeded = context => true;
      options.MinimumSameSitePolicy = SameSiteMode.None;
    });

    services
      .AddFastEndpoints()
      .AddAuthorization();

    var authentication = Guard.Against.Null(appConfigOptions.Authentication);

    switch (authentication.Type)
    {
      case AppConfigOptionsAuthenticationEnum.JWT:
        services
          .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options =>
          {
            var authentication = Guard.Against.Null(appConfigOptions.Authentication);

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
            var keycloak = Guard.Against.Null(appConfigOptions.Keycloak);

            string rootUrl = $"{keycloak.BaseUrl}/realms/{keycloak.Realm}";

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

            options.RequireHttpsMetadata = false; // Only in develop environment
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
