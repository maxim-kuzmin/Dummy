namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.GrpcServer.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру интеграции микросервиса "Писатель" приложения, привязанную к серверу Grpc.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppIntegrationMicroserviceWriterViaSQLInfrastructureTiedToGrpcServer(
    this IServiceCollection services,
    ILogger logger)
  {
    services.AddGrpc(options =>
    {
      options.EnableDetailedErrors = true;
    });

    logger.LogInformation("Added application integration microservice Writer infrastructure tied to Grpc server");

    return services;
  }

  /// <summary>
  /// Использовать инфраструктуру интеграции микросервиса "Писатель" приложения, привязанную к серверу Grpc.
  /// </summary>
  /// <param name="app">Приложение.</param>
  /// <param name="logger">Логгер.</param>
  /// <returns>Приложение.</returns>
  public static WebApplication UseAppIntegrationMicroserviceWriterViaSQLInfrastructureTiedToGrpcServer(
    this WebApplication app,
    ILogger logger)
  {    
    app.MapGrpcService<AppOutgoingEventService>();
    app.MapGrpcService<AppOutgoingEventPayloadService>();
    app.MapGrpcService<AuthService>();
    app.MapGrpcService<DummyItemService>();

    logger.LogInformation("Used  application integration microservice Writer infrastructure tied to Grpc server");

    return app;
  }
}
