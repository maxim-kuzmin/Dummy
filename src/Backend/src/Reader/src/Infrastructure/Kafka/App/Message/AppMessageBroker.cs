namespace Makc.Dummy.Reader.Infrastructure.Kafka.App.Message;

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
  public IAppMessageConsumer CreateMessageConsumer()
  {
    return new AppMessageConsumer(GetCreatedConsumer, _logger);
  }

  /// <inheritdoc/>
  protected override ConsumerConfig? GetConsumerConfig()
  {
    return _options.Consumer;
  }

  /// <inheritdoc/>
  protected override ProducerConfig? GetProducerConfig()
  {
    return null;
  }
}
