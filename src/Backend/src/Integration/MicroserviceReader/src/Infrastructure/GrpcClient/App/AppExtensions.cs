namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.GrpcClient.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру интеграции микросервиса "Читатель" приложения, привязанную к клиенту Grpc.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="microserviceReaderEndpoint">Конечная точка микросервиса "Читатель".</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppIntegrationMicroserviceReaderInfrastructureTiedToGrpcClient(
      this IServiceCollection services,
      ILogger logger,
      string microserviceReaderEndpoint)
  {
    services.AddTransient<IAppIncomingEventCommandService, AppIncomingEventCommandService>();
    services.AddTransient<IAppIncomingEventQueryService, AppIncomingEventQueryService>();

    services.AddGrpcClient<AppIncomingEventGrpcClient>(
      AppSettings.AppIncomingEventGrpcClientName,
      grpcOptions =>
      {
        grpcOptions.Address = new Uri(microserviceReaderEndpoint);
      })
      .AddCallCredentials((context, metadata, serviceProvider) => Task.CompletedTask)
      .ConfigureChannel(grpcChannelOptions =>
      {
        grpcChannelOptions.UnsafeUseInsecureChannelCallCredentials = true;
      });

    services.AddTransient<IAppIncomingEventPayloadCommandService, AppIncomingEventPayloadCommandService>();
    services.AddTransient<IAppIncomingEventPayloadQueryService, AppIncomingEventPayloadQueryService>();

    services.AddGrpcClient<AppIncomingEventPayloadGrpcClient>(
      AppSettings.AppIncomingEventPayloadGrpcClientName,
      grpcOptions =>
      {
        grpcOptions.Address = new Uri(microserviceReaderEndpoint);
      })
      .AddCallCredentials((context, metadata, serviceProvider) => Task.CompletedTask)
      .ConfigureChannel(grpcChannelOptions =>
      {
        grpcChannelOptions.UnsafeUseInsecureChannelCallCredentials = true;
      });

    services.AddTransient<IDummyItemCommandService, DummyItemCommandService>();
    services.AddTransient<IDummyItemQueryService, DummyItemQueryService>();

    services.AddGrpcClient<DummyItemGrpcClient>(
      AppSettings.DummyItemGrpcClientName,
      grpcOptions =>
      {
        grpcOptions.Address = new Uri(microserviceReaderEndpoint);
      })
      .AddCallCredentials((context, metadata, serviceProvider) => Task.CompletedTask)
      .ConfigureChannel(grpcChannelOptions =>
      {
        grpcChannelOptions.UnsafeUseInsecureChannelCallCredentials = true;
      });

    logger.LogInformation("Added application integration microservice Reader infrastructure tied to Grpc client");

    return services;
  }
}
