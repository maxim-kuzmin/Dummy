namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.GrpcClient.App;

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
  public static IServiceCollection AddAppIntegrationMicroserviceWriterViaSQLInfrastructureTiedToGrpcClient(
      this IServiceCollection services,
      ILogger logger,
      AppConfigOptionsDomainAuthSection? domainAuthSection,
      string microserviceWriterEndpoint)
  {
    services.AddTransient<IAppOutgoingEventCommandService, AppOutgoingEventCommandService>();
    services.AddTransient<IAppOutgoingEventQueryService, AppOutgoingEventQueryService>();

    services.AddGrpcClient<AppOutgoingEventGrpcClient>(
      AppSettings.AppOutgoingEventGrpcClientName,
      grpcOptions =>
      {
        grpcOptions.Address = new Uri(microserviceWriterEndpoint);
      })
      .AddCallCredentials((context, metadata, serviceProvider) => Task.CompletedTask)
      .ConfigureChannel(grpcChannelOptions =>
      {
        grpcChannelOptions.UnsafeUseInsecureChannelCallCredentials = true;
      });

    services.AddTransient<IAppOutgoingEventPayloadCommandService, AppOutgoingEventPayloadCommandService>();
    services.AddTransient<IAppOutgoingEventPayloadQueryService, AppOutgoingEventPayloadQueryService>();

    services.AddGrpcClient<AppOutgoingEventPayloadGrpcClient>(
      AppSettings.AppOutgoingEventPayloadGrpcClientName,
      grpcOptions =>
      {
        grpcOptions.Address = new Uri(microserviceWriterEndpoint);
      })
      .AddCallCredentials((context, metadata, serviceProvider) => Task.CompletedTask)
      .ConfigureChannel(grpcChannelOptions =>
      {
        grpcChannelOptions.UnsafeUseInsecureChannelCallCredentials = true;
      });

    if (domainAuthSection?.Type == AppConfigOptionsAuthenticationEnum.JWT)
    {
      services.AddTransient<IAuthCommandService, AuthCommandService>();

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
    }

    services.AddTransient<IDummyItemCommandService, DummyItemCommandService>();
    services.AddTransient<IDummyItemQueryService, DummyItemQueryService>();

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
