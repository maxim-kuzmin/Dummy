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
  /// <param name="appConfigSectionRabbitMQ">Раздел RabbitMQ в конфигурации приложения.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppInfrastructureTiedToRabbitMQ(
    this IServiceCollection services,
    ILogger logger,
    AppConfigOptionsRabbitMQSection? appConfigOptionsRabbitMQSection)
  {
    if (appConfigOptionsRabbitMQSection != null)
    {
      var appMessageBusFactory = new AppMessageBusFactory(appConfigOptionsRabbitMQSection);

      services.AddSingleton<IAppMessageBusFactory>(x => appMessageBusFactory);
    }

    logger.LogInformation("Added application infrastructure tied to RabbitMQ");

    return services;
  }
}
