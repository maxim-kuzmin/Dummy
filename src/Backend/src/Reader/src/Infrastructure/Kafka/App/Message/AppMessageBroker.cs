namespace Makc.Dummy.Reader.Infrastructure.Kafka.App.Message;

/// <summary>
/// Брокер сообщений приложения.
/// </summary>
public class AppMessageBroker : MessageBroker, IAppMessageBroker
{
  private readonly ConsumerConfig _consumerConfig;

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
    _consumerConfig = new(options.Consumer)
    {
      AutoOffsetReset = AutoOffsetReset.Earliest,
      EnableAutoCommit = true,
      EnableAutoOffsetStore = false // https://docs.confluent.io/kafka-clients/dotnet/current/overview.html#store-offsets
    };

    _logger = logger;
  }

  /// <inheritdoc/>
  public IAppMessageConsumer CreateMessageConsumer()
  {
    return new AppMessageConsumer(GetCreatedConsumer, _logger);
  }

  /// <inheritdoc/>
  protected override ConsumerConfig? GetConsumerConfig()
  {
    return _consumerConfig;
  }

  /// <inheritdoc/>
  protected override ProducerConfig? GetProducerConfig()
  {
    return null;
  }
}
