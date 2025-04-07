namespace Makc.Dummy.Reader.Infrastructure.RabbitMQ.App.Message;

/// <summary>
/// Брокер сообщений приложения.
/// </summary>
/// <param name="options">Параметры.</param>
/// <param name="_logger">Логгер.</param>
public class AppMessageBroker(
  AppConfigOptionsRabbitMQSection? options,
  ILogger<AppMessageBroker> _logger) :
  MessageBroker<IAppMessageConsumer, IMessageProducer>(options, _logger),
  IAppMessageBroker
{
  /// <inheritdoc/>
  protected override IAppMessageConsumer? CreateMessageConsumer(IChannel channel)
  {
    return new AppMessageConsumer(channel, _logger);
  }

  /// <inheritdoc/>
  protected override IMessageProducer? CreateMessageProducer(IChannel channel)
  {
    return null;
  }
}
