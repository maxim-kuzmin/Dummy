namespace Makc.Dummy.Gateway.Infrastructure.GrpcForMicroserviceWriter.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к Grpc для микросервиса "Писатель".
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="domainAuthSection">
  /// Раздел аутентификации в параметрах конфигурации предметной области приложения.
  /// </param>
  /// <param name="microserviceWriterEndpoint">Конечная точка микросервиса "Писатель".</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToGrpcForMicroserviceWriter(
      this IServiceCollection services,
      ILogger logger,
      AppConfigOptionsDomainAuthSection? domainAuthSection,
      string microserviceWriterEndpoint)
  {
    if (domainAuthSection?.Type == AppConfigOptionsAuthenticationEnum.JWT)
    {
      services.AddTransient<IAuthCommandService, AuthCommandService>();
    }

    services.AddTransient<IDummyItemCommandService, DummyItemCommandService>();
    services.AddTransient<IDummyItemQueryService, DummyItemQueryService>();

    services.AddGrpcClient<AuthGrpcClient>(
      AuthSettings.AuthGrpcClientName,
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
      AuthSettings.DummyItemGrpcClientName,
      grpcOptions =>
      {
        grpcOptions.Address = new Uri(microserviceWriterEndpoint);
      })
      .AddCallCredentials((context, metadata, serviceProvider) => Task.CompletedTask)
      .ConfigureChannel(grpcChannelOptions =>
      {
        grpcChannelOptions.UnsafeUseInsecureChannelCallCredentials = true;
      });

    logger.LogInformation("Added application infrastructure tied to Grpc for microcervice Writer");

    return services;
  }
}
