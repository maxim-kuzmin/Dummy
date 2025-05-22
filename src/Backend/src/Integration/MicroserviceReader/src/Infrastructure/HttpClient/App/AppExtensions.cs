namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.HttpClient.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру интеграции микросервиса "Читатель" приложения, привязанную к клиенту HTTP.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="microserviceReaderEndpoint">Конечная точка микросервиса "Читатель".</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppIntegrationMicroserviceReaderInfrastructureTiedToHttpClient(
      this IServiceCollection services,
      ILogger logger,
      string microserviceReaderEndpoint)
  {
    services.AddTransient<IAppIncomingEventCommandService, AppIncomingEventCommandService>();
    services.AddTransient<IAppIncomingEventQueryService, AppIncomingEventQueryService>();

    services.AddTransient<IAppIncomingEventPayloadCommandService, AppIncomingEventPayloadCommandService>();
    services.AddTransient<IAppIncomingEventPayloadQueryService, AppIncomingEventPayloadQueryService>();

    services.AddTransient<IDummyItemCommandService, DummyItemCommandService>();
    services.AddTransient<IDummyItemQueryService, DummyItemQueryService>();

    const string userAgent = nameof(Dummy);

    services.AddHttpClient(
      AppSettings.HttpClientName,
      httpClient =>
      {
        httpClient.BaseAddress = new Uri(microserviceReaderEndpoint);

        httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);
      })
      .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
      {
        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
      });

    logger.LogInformation("Added application integration microservice Reader infrastructure tied to HTTP client");

    return services;
  }
}
