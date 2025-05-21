namespace Makc.Dummy.Gateway.Infrastructure.HttpForKeycloak.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить варианты использования предметной области приложения для поставщика OpenID "Keycloak".
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="configurationSection">Раздел конфигурации.</param>
  /// <param name="keycloakEndpoint">Конечная точка поставщика OpenID "Keycloak".</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToHttpForKeycloak(
    this IServiceCollection services,
    ILogger logger,
    IConfigurationSection configurationSection,
    string keycloakEndpoint)
  {
    services.AddTransient<IAuthCommandService, AuthCommandService>();

    services.Configure<AppConfigOptionsInfrastructureKeycloakSection>(configurationSection);

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


    logger.LogInformation("Added application infrastructure tied to Http for Keycloak");

    return services;
  }
}
