namespace Makc.Dummy.Gateway.Infrastructure.HttpForWriter.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к Http.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="writerEndpoint">Конечная точка писателя.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToHttp(
      this IServiceCollection services,
      ILogger logger,
      string writerEndpoint)
  {
    services.AddTransient<IAppCommandService, AppCommandService>();
    services.AddTransient<IDummyItemCommandService, DummyItemCommandService>();
    services.AddTransient<IDummyItemQueryService, DummyItemQueryService>();

    const string userAgent = nameof(Dummy);

    services.AddHttpClient(
      AppSettings.WriterDummyItemClientName,
      httpClient =>
      {
        httpClient.BaseAddress = new Uri(writerEndpoint);

        httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);
      })
      .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
      {
        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
      });

    logger.LogInformation("Added application infrastructure tied to Http");

    return services;
  }

  /// <summary>
  /// Преобразовать к содержимому запроса HTTP.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Содержимое запроса HTTP.</returns>
  public static JsonContent ToHttpRequestContent(this AppLoginActionCommand command)
  {
    return JsonContent.Create(command);
  }
}
