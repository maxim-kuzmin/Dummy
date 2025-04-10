namespace Makc.Dummy.Reader.Infrastructure.RabbitMQ.App.Message;

/// <summary>
/// Брокер сообщений приложения.
/// </summary>
/// <param name="options">Параметры.</param>
/// <param name="_logger">Логгер.</param>
public class AppMessageBroker(
  AppConfigOptionsRabbitMQSection options,
  ILogger<AppMessageBroker> _logger) : MessageBroker(options, _logger), IAppMessageBroker
{
  /// <inheritdoc/>
  public IAppMessageConsumer CreateMessageConsumer()
  {
    return new AppMessageConsumer(GetCreatedChannel, _logger);
  }
}
