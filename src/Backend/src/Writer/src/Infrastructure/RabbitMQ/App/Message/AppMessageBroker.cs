namespace Makc.Dummy.Writer.Infrastructure.RabbitMQ.App.Message;

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
  public IAppMessageProducer CreateMessageProducer()
  {
    return new AppMessageProducer(GetCreatedChannel, _logger);
  }
}
