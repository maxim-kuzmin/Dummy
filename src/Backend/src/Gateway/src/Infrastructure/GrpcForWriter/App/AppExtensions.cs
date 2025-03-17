namespace Makc.Dummy.Gateway.Infrastructure.GrpcForWriter.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к Grpc для микросервиса Писатель.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="writerEndpoint">Конечная точка микросервиса Писатель.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToGrpcForWriter(
      this IServiceCollection services,
      ILogger logger,
      string writerEndpoint)
  {
    services.AddTransient<IAppCommandService, AppCommandService>();
    services.AddTransient<IDummyItemCommandService, DummyItemCommandService>();
    services.AddTransient<IDummyItemQueryService, DummyItemQueryService>();

    services.AddGrpcClient<AppGrpcClient>(
      AppSettings.AppClientName,
      grpcOptions =>
      {
        grpcOptions.Address = new Uri(writerEndpoint);
      })
      .AddCallCredentials((context, metadata, serviceProvider) => Task.CompletedTask)
      .ConfigureChannel(grpcChannelOptions =>
      {
        grpcChannelOptions.UnsafeUseInsecureChannelCallCredentials = true;
      });

    services.AddGrpcClient<DummyItemGrpcClient>(
      AppSettings.DummyItemClientName,
      grpcOptions =>
      {
        grpcOptions.Address = new Uri(writerEndpoint);
      })
      .AddCallCredentials((context, metadata, serviceProvider) => Task.CompletedTask)
      .ConfigureChannel(grpcChannelOptions =>
      {
        grpcChannelOptions.UnsafeUseInsecureChannelCallCredentials = true;
      });

    logger.LogInformation("Added application infrastructure tied to Grpc for Writer");

    return services;
  }

  /// <summary>
  /// Преобразовать к запросу действия по входу в приложение.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <returns>Запрос действия по входу в приложение.</returns>
  public static AppLoginActionRequest ToAppLoginActionRequest(this AppLoginActionCommand command)
  {
    return new()
    {
      UserName = command.UserName,
      Password = command.Password,
    };
  }

  /// <summary>
  /// Преобразовать к объекту передачи данных действия по входу в приложение.
  /// </summary>
  /// <param name="reply">Ответ.</param>
  /// <returns>Объект передачи данных действия по входу в приложение.</returns>
  public static AppLoginActionDTO ToAppLoginActionDTO(this AppLoginActionReply reply)
  {
    return new(reply.UserName, reply.AccessToken);
  }
}
