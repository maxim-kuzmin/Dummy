namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Infrastructure.RabbitMQ.App.Message;

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
  public IAppMessageConsumer CreateMessageConsumer()
  {
    return new AppMessageConsumer(GetCreatedChannel, _logger);
  }
}
