namespace Makc.Dummy.MicroserviceWriter.Infrastructure.RabbitMQ.App.Message;

/// <summary>
/// Брокер сообщений приложения.
/// </summary>
/// <param name="appConfigOptions">Параметры конфигурации приложения.</param>
/// <param name="_logger">Логгер.</param>
public class AppMessageBroker(
  AppConfigOptionsInfrastructureRabbitMQSection appConfigOptions,
  ILogger<AppMessageBroker> _logger) : MessageBroker(appConfigOptions, _logger), IAppMessageBroker
{
  /// <inheritdoc/>
  public IAppMessageProducer CreateMessageProducer()
  {
    return new AppMessageProducer(GetCreatedChannel, _logger);
  }
}
