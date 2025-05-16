namespace Makc.Dummy.Gateway.Infrastructure.HttpForMicroserviceReader.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к Http для микросервиса "Читатель".
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="readerEndpoint">Конечная точка микросервиса "Читатель".</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToHttpForMicroserviceReader(
      this IServiceCollection services,
      ILogger logger,
      string readerEndpoint)
  {
    services.AddTransient<IDummyItemCommandService, DummyItemCommandService>();
    services.AddTransient<IDummyItemQueryService, DummyItemQueryService>();

    const string userAgent = nameof(Dummy);

    services.AddHttpClient(
      AppSettings.HttpClientName,
      httpClient =>
      {
        httpClient.BaseAddress = new Uri(readerEndpoint);

        httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);
      })
      .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
      {
        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
      });

    logger.LogInformation("Added application infrastructure tied to Http for Reader");

    return services;
  }
}
