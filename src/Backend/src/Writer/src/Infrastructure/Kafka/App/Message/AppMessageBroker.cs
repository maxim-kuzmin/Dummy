namespace Makc.Dummy.Writer.Infrastructure.Kafka.App.Message;

/// <summary>
/// Брокер сообщений приложения.
/// </summary>
/// <param name="options">Параметры.</param>
/// <param name="_logger">Логгер.</param>
public class AppMessageBroker(
  AppConfigOptionsKafkaSection options,
  ILogger<AppMessageBroker> _logger) : MessageBroker(options, _logger), IAppMessageBroker
{
  /// <inheritdoc/>
  public IAppMessageProducer CreateMessageProducer()
  {
    return new AppMessageProducer(GetCreatedProducer, _logger);
  }

  /// <inheritdoc/>
  protected override ConsumerConfig? CreateConsumerConfig(ClientConfig clientConfig)
  {
    return null;
  }

  /// <inheritdoc/>
  protected override ProducerConfig? CreateProducerConfig(ClientConfig clientConfig)
  {
    return new(clientConfig);
  }
}
