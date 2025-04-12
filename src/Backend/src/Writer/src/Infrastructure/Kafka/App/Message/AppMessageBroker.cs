namespace Makc.Dummy.Writer.Infrastructure.Kafka.App.Message;

/// <summary>
/// Брокер сообщений приложения.
/// </summary>
/// <param name="_options">Параметры.</param>
/// <param name="_logger">Логгер.</param>
public class AppMessageBroker(
  AppConfigOptionsMessageBrokerSection _options,
  ILogger<AppMessageBroker> _logger) : MessageBroker(_options.TimeoutInMillisecondsToRetry, _logger), IAppMessageBroker
{
  /// <inheritdoc/>
  public IAppMessageProducer CreateMessageProducer()
  {
    return new AppMessageProducer(GetCreatedProducer, _logger);
  }

  /// <inheritdoc/>
  protected override ConsumerConfig? GetConsumerConfig()
  {
    return null;
  }

  /// <inheritdoc/>
  protected override ProducerConfig? GetProducerConfig()
  {
    return _options.Producer;
  }
}
