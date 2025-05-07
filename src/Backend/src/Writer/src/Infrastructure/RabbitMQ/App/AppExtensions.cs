namespace Makc.Dummy.Writer.Infrastructure.RabbitMQ.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к брокеру сообщений RabbitMQ.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appConfigOptions">Параметры конфигурации приложения.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToRabbitMQ(
    this IServiceCollection services,
    ILogger logger,
    AppConfigOptionsInfrastructureRabbitMQSection appConfigOptions)
  {
    services.AddSingleton<IAppMessageBroker>(x => new AppMessageBroker(
      appConfigOptions,
      x.GetRequiredService<ILogger<AppMessageBroker>>()));

    services.AddTransient(x => x.GetRequiredService<IAppMessageBroker>().CreateMessageProducer());

    logger.LogInformation("Added application infrastructure tied to RabbitMQ");

    return services;
  }
}
