namespace Makc.Dummy.Gateway.Infrastructure.HttpForWriter.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к Http для микросервиса Писатель.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appConfigOptionsAuthenticationSection">
  /// Раздел аутентификации в параметрах конфигурации приложения.
  /// </param>
  /// <param name="writerEndpoint">Конечная точка микросервиса Писатель.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToHttpForWriter(
      this IServiceCollection services,
      ILogger logger,
      AppConfigOptionsAuthenticationSection? appConfigOptionsAuthenticationSection,
      string writerEndpoint)
  {
    if (appConfigOptionsAuthenticationSection?.Type == AppConfigOptionsAuthenticationEnum.JWT)
    {
      services.AddTransient<IAuthCommandService, AuthCommandService>();
    }

    services.AddTransient<IDummyItemCommandService, DummyItemCommandService>();
    services.AddTransient<IDummyItemQueryService, DummyItemQueryService>();

    const string userAgent = nameof(Dummy);

    services.AddHttpClient(
      AuthSettings.HttpClientName,
      httpClient =>
      {
        httpClient.BaseAddress = new Uri(writerEndpoint);

        httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);
      })
      .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
      {
        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
      });

    logger.LogInformation("Added application infrastructure tied to Http for Writer");

    return services;
  }
}
