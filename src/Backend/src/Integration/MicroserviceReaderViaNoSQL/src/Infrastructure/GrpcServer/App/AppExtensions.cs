namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.GrpcServer.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру интеграции микросервиса "Читатель" приложения, привязанную к серверу Grpc.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppIntegrationMicroserviceReaderViaNoSQLInfrastructureTiedToGrpcServer(
    this IServiceCollection services,
    ILogger logger)
  {
    services.AddGrpc(options =>
    {
      options.EnableDetailedErrors = true;
    });

    logger.LogInformation("Added application integration microservice Reader infrastructure tied to Grpc server");

    return services;
  }

  /// <summary>
  /// Использовать инфраструктуру интеграции микросервиса "Читатель" приложения, привязанную к серверу Grpc.
  /// </summary>
  /// <param name="app">Приложение.</param>
  /// <param name="logger">Логгер.</param>
  /// <returns>Приложение.</returns>
  public static WebApplication UseAppIntegrationMicroserviceReaderViaNoSQLInfrastructureTiedToGrpcServer(
    this WebApplication app,
    ILogger logger)
  {
    app.MapGrpcService<AppIncomingEventService>();
    app.MapGrpcService<AppIncomingEventPayloadService>();
    app.MapGrpcService<DummyItemService>();

    logger.LogInformation("Used application infrastructure tied to Grpc");

    return app;
  }
}
