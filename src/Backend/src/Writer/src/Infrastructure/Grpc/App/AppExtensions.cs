namespace Makc.Dummy.Writer.Infrastructure.Grpc.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к Grpc.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appConfigOptions">Параметры конфигурации приложения.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToGrpc(
    this IServiceCollection services,
    ILogger logger)
  {
    services.AddGrpc(options =>
    {
      options.EnableDetailedErrors = true;
    });

    logger.LogInformation("Added application infrastructure tied to Grpc");

    return services;
  }

  /// <summary>
  /// Использовать инфраструктуру приложения, привязанную к Grpc.
  /// </summary>
  /// <param name="app">Приложение.</param>
  /// <param name="logger">Логгер.</param>
  /// <returns>Приложение.</returns>
  public static WebApplication UseAppInfrastructureTiedToGrpc(this WebApplication app, ILogger logger)
  {    
    app.MapGrpcService<AppEventService>();
    app.MapGrpcService<AppEventPayloadService>();
    app.MapGrpcService<AuthService>();
    app.MapGrpcService<DummyItemService>();

    logger.LogInformation("Used application infrastructure tied to Grpc");

    return app;
  }
}
