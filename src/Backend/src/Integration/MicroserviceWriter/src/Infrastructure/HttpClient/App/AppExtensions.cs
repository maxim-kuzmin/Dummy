namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.HttpClient.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к Http для микросервиса "Писатель".
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appConfigOptionsDomainAuthSection">
  /// Раздел аутентификации в параметрах конфигурации предметной области приложения.
  /// </param>
  /// <param name="microserviceWriterEndpoint">Конечная точка микросервиса "Писатель".</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToHttpForMicroserviceWriter(
      this IServiceCollection services,
      ILogger logger,
      AppConfigOptionsDomainAuthSection? appConfigOptionsDomainAuthSection,
      string microserviceWriterEndpoint)
  {
    if (appConfigOptionsDomainAuthSection?.Type == AppConfigOptionsAuthenticationEnum.JWT)
    {
      services.AddTransient<IAuthCommandService, AuthCommandService>();
    }

    services.AddTransient<IDummyItemCommandService, DummyItemCommandService>();
    services.AddTransient<IDummyItemQueryService, DummyItemQueryService>();

    const string userAgent = nameof(Dummy);

    services.AddHttpClient(
      AppSettings.HttpClientName,
      httpClient =>
      {
        httpClient.BaseAddress = new Uri(microserviceWriterEndpoint);

        httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);
      })
      .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
      {
        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
      });

    logger.LogInformation("Added application infrastructure tied to Http for microservice Writer");

    return services;
  }
}
