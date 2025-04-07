namespace Makc.Dummy.Writer.Infrastructure.RabbitMQ.App.Message;

/// <summary>
/// Брокер сообщений приложения.
/// </summary>
/// <param name="options">Параметры.</param>
/// <param name="_logger">Логгер.</param>
public class AppMessageBroker(
  AppConfigOptionsRabbitMQSection? options,
  ILogger<AppMessageBroker> _logger) :
  MessageBroker<IMessageConsumer, IAppMessageProducer>(options, _logger),
  IAppMessageBroker
{
  /// <inheritdoc/>
  protected override IMessageConsumer? CreateMessageConsumer(IChannel channel)
  {
    return null;
  }

  /// <inheritdoc/>
  protected override IAppMessageProducer? CreateMessageProducer(IChannel channel)
  {
    return new AppMessageProducer(channel, _logger);
  }
}
