namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.GrpcClient.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру интеграции микросервиса "Писатель" приложения, привязанную к клиенту Grpc.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="domainAuthSection">
  /// Раздел аутентификации в параметрах конфигурации предметной области приложения.
  /// </param>
  /// <param name="microserviceWriterEndpoint">Конечная точка микросервиса "Писатель".</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppIntegrationMicroserviceWriterInfrastructureTiedToGrpcClient(
      this IServiceCollection services,
      ILogger logger,
      AppConfigOptionsDomainAuthSection? domainAuthSection,
      string microserviceWriterEndpoint)
  {
    services.AddTransient<IAppOutgoingEventCommandService, AppOutgoingEventCommandService>();
    services.AddTransient<IAppOutgoingEventQueryService, AppOutgoingEventQueryService>();

    services.AddTransient<IAppOutgoingEventPayloadCommandService, AppOutgoingEventPayloadCommandService>();
    services.AddTransient<IAppOutgoingEventPayloadQueryService, AppOutgoingEventPayloadQueryService>();

    if (domainAuthSection?.Type == AppConfigOptionsAuthenticationEnum.JWT)
    {
      services.AddTransient<IAuthCommandService, AuthCommandService>();
    }

    services.AddTransient<IDummyItemCommandService, DummyItemCommandService>();
    services.AddTransient<IDummyItemQueryService, DummyItemQueryService>();

    services.AddGrpcClient<AuthGrpcClient>(
      AppSettings.AuthGrpcClientName,
      grpcOptions =>
      {
        grpcOptions.Address = new Uri(microserviceWriterEndpoint);
      })
      .AddCallCredentials((context, metadata, serviceProvider) => Task.CompletedTask)
      .ConfigureChannel(grpcChannelOptions =>
      {
        grpcChannelOptions.UnsafeUseInsecureChannelCallCredentials = true;
      });

    services.AddGrpcClient<DummyItemGrpcClient>(
      AppSettings.DummyItemGrpcClientName,
      grpcOptions =>
      {
        grpcOptions.Address = new Uri(microserviceWriterEndpoint);
      })
      .AddCallCredentials((context, metadata, serviceProvider) => Task.CompletedTask)
      .ConfigureChannel(grpcChannelOptions =>
      {
        grpcChannelOptions.UnsafeUseInsecureChannelCallCredentials = true;
      });

    logger.LogInformation("Added application integration microservice Writer infrastructure tied to Grpc client");

    return services;
  }
}
