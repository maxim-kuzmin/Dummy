namespace Makc.Dummy.MicroserviceWriterViaSQL.Infrastructure.Kafka.App.Message;

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
  /// <param name="appConfigOptions">Параметры конфигурации приложения.</param>
  /// <param name="logger">Логгер.</param>
  public AppMessageBroker(
    AppConfigOptionsMessageBrokerSection appConfigOptions,
    ILogger<AppMessageBroker> logger) : base(appConfigOptions.TimeoutInMillisecondsToRetry, logger)
  {
    _producerConfig = new(appConfigOptions.Producer)
    {
      EnableIdempotence = true
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
