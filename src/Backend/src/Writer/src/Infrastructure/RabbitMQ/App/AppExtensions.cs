namespace Makc.Dummy.Writer.Infrastructure.RabbitMQ.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить инфраструктуру приложения, привязанную к RabbitMQ.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <param name="appConfigOptionsRabbitMQSection">
  /// Раздел брокера сообщений RabbitMQ в параметрах конфигурации приложения.
  /// </param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToRabbitMQ(
    this IServiceCollection services,
    ILogger logger,
    AppConfigOptionsRabbitMQSection? appConfigOptionsRabbitMQSection)
  {
    services.AddSingleton<IAppMessageBroker>(x => new AppMessageBroker(
      appConfigOptionsRabbitMQSection,
      x.GetRequiredService<ILogger<AppMessageBroker>>()));

    services.AddTransient(x => x.GetRequiredService<IAppMessageBroker>().CreateMessageProducer());

    logger.LogInformation("Added application infrastructure tied to RabbitMQ");

    return services;
  }
}
