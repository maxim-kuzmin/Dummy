namespace Makc.Dummy.Gateway.Infrastructure.HttpForKeycloak.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить варианты использования домена приложения для поставщика OpenID Keycloak.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appConfigOptionsAuthenticationSection">
  /// Раздел аутентификации в параметрах конфигурации приложения.
  /// </param>
  /// <param name="appConfigKeycloakSection">Раздел поставщика OpenID Keycloak в конфигурации приложения.</param>
  /// <param name="keycloakEndpoint">Конечная точка поставщика OpenID Keycloak.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToHttpForKeycloak(
    this IServiceCollection services,
    ILogger logger,
    AppConfigOptionsAuthenticationSection? appConfigOptionsAuthenticationSection,
    IConfigurationSection? appConfigKeycloakSection,
    string? keycloakEndpoint)
  {
    if (appConfigOptionsAuthenticationSection?.Type == AppConfigOptionsAuthenticationEnum.Keycloak)
    {
      services.AddTransient<IAuthCommandService, AuthCommandService>();

      Guard.Against.Null(appConfigKeycloakSection);      

      services.Configure<AppConfigOptionsKeycloakSection>(appConfigKeycloakSection);

      Guard.Against.Null(keycloakEndpoint);

      const string userAgent = nameof(Dummy);

      services.AddHttpClient(
        AuthSettings.HttpClientName,
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

    logger.LogInformation("Added application infrastructure tied to Http for Keycloak");

    return services;
  }
}
