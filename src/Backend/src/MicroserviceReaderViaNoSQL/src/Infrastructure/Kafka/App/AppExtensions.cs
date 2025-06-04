namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Infrastructure.Kafka.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к брокеру сообщений "Kafka".
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appConfigOptions">Параметры конфигурации приложения.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToKafka(
    this IServiceCollection services,
    ILogger logger,
    AppConfigOptionsMessageBrokerSection appConfigOptions)
  {
    services.AddSingleton<IAppMessageBroker>(x => new AppMessageBroker(
      appConfigOptions,
      x.GetRequiredService<ILogger<AppMessageBroker>>()));

    services.AddTransient(x => x .GetRequiredService<IAppMessageBroker>().CreateMessageConsumer());

    logger.LogInformation("Added application infrastructure tied to Kafka");

    return services;
  }
}
