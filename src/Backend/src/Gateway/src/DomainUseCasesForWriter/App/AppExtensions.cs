namespace Makc.Dummy.Gateway.DomainUseCasesForWriter.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить варианты использования домена приложения.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appConfigAuthenticationSection">Раздел аутентификации в конфигурации приложения.</param>
  /// <param name="appConfigKeycloakSection">Раздел поставщика OpenID Keycloak в конфигурации приложения.</param>
  /// <param name="keycloakEndpoint">Конечная точка поставщика OpenID Keycloak.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppDomainUseCases(
    this IServiceCollection services,
    ILogger logger,
    IConfigurationSection? appConfigAuthenticationSection,
    IConfigurationSection? appConfigKeycloakSection,
    string? keycloakEndpoint)
  {
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

    services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

    if (appConfigAuthenticationSection != null)
    {
      services.Configure<AppConfigOptionsAuthenticationSection>(appConfigAuthenticationSection);
    }

    if (appConfigKeycloakSection != null)
    {
      services.Configure<AppConfigOptionsKeycloakSection>(appConfigKeycloakSection);

      Guard.Against.Null(keycloakEndpoint);

      const string userAgent = nameof(Dummy);

      services.AddHttpClient(
        AppSettings.KeycloakClientName,
        httpClient =>
        {
          httpClient.BaseAddress = new Uri(keycloakEndpoint);

          httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);
        })
        .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
        {
          ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        });
    }

    logger.LogInformation("Added application domain use cases");

    return services;
  }
}
