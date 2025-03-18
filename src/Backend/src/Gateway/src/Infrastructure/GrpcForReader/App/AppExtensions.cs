namespace Makc.Dummy.Gateway.Infrastructure.GrpcForReader.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к Grpc для микросервиса Читатель.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="readerEndpoint">Конечная точка микросервиса Читатель.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToGrpcForReader(
      this IServiceCollection services,
      ILogger logger,
      string readerEndpoint)
  {
    services.AddTransient<IDummyItemCommandService, DummyItemCommandService>();
    services.AddTransient<IDummyItemQueryService, DummyItemQueryService>();

    services.AddGrpcClient<DummyItemGrpcClient>(
      AppSettings.DummyItemGrpcClientName,
      grpcOptions =>
      {
        grpcOptions.Address = new Uri(readerEndpoint);
      })
      .AddCallCredentials((context, metadata, serviceProvider) => Task.CompletedTask)
      .ConfigureChannel(grpcChannelOptions =>
      {
        grpcChannelOptions.UnsafeUseInsecureChannelCallCredentials = true;
      });

    logger.LogInformation("Added application infrastructure tied to Grpc for Reader");

    return services;
  }
}
