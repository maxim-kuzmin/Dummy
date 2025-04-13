namespace Makc.Dummy.Writer.Infrastructure.Kafka.App.Message;

/// <summary>
/// Брокер сообщений приложения.
/// </summary>
public class AppMessageBroker : MessageBroker, IAppMessageBroker
{
  private readonly ProducerConfig _producerConfig;

  private readonly ILogger _logger;

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="options">Параметры.</param>
  /// <param name="logger">Логгер.</param>
  public AppMessageBroker(
    AppConfigOptionsMessageBrokerSection options,
    ILogger<AppMessageBroker> logger) : base(options.TimeoutInMillisecondsToRetry, logger)
  {
    _producerConfig = new(options.Producer)
    {
      Acks = Acks.All      
    };

    _logger = logger;
  }

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
    return _producerConfig;
  }
}
