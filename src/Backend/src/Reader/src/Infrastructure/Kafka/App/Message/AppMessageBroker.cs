namespace Makc.Dummy.Reader.Infrastructure.Kafka.App.Message;

/// <summary>
/// Брокер сообщений приложения.
/// </summary>
/// <param name="options">Параметры.</param>
/// <param name="_logger">Логгер.</param>
public class AppMessageBroker(
  AppConfigOptionsKafkaSection? options,
  ILogger<AppMessageBroker> _logger) : MessageBroker(options, _logger), IAppMessageBroker
{
  /// <inheritdoc/>
  public IAppMessageConsumer CreateMessageConsumer()
  {
    return new AppMessageConsumer(GetCreatedConsumer, _logger);
  }

  /// <inheritdoc/>
  protected override ConsumerConfig? CreateConsumerConfig(ClientConfig clientConfig)
  {
    return new(clientConfig)
    {
      GroupId = "Makc.Dummy.Reader",
      AutoOffsetReset = AutoOffsetReset.Earliest
    };
  }

  /// <inheritdoc/>
  protected override ProducerConfig? CreateProducerConfig(ClientConfig clientConfig)
  {
    return null;
  }
}
