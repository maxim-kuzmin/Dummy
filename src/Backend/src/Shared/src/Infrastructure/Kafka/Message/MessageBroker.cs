using Confluent.Kafka;

namespace Makc.Dummy.Shared.Infrastructure.Kafka.Message;

/// <summary>
/// Брокер сообщений.
/// </summary>
public abstract class MessageBroker : IMessageBroker, IDisposable
{
  private readonly ClientConfig _clientConfig;

  private readonly ILogger _logger;

  private readonly int _timeoutToRetry;

  private IConsumer<string, string>? _consumer;

  private IProducer<string, string>? _producer;

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="options">Параметры.</param>
  /// <param name="logger">Логгер.</param>
  public MessageBroker(AppConfigOptionsKafkaSection options, ILogger logger)
  {
    _logger = logger;

    _clientConfig = new()
    {
      BootstrapServers = options.BootstrapServers,
      Acks = Acks.All
    };

    _timeoutToRetry = options.TimeoutInMillisecondsToRetry;
  }

  public async Task Connect(CancellationToken cancellationToken)
  {
    while (!cancellationToken.IsCancellationRequested)
    {
      try
      {
        var consumerConfig = CreateConsumerConfig(_clientConfig);

        _logger.LogDebug("MAKC:MessageBroker:Connect:ConsumerConfig {not}created", consumerConfig != null ? string.Empty : "not ");

        if (consumerConfig != null)
        {
          _consumer = new ConsumerBuilder<string, string>(consumerConfig).Build();

          _logger.LogDebug("MAKC:MessageBroker:Connect:Consumer created");
        }        
        
        var producerConfig = CreateProducerConfig(_clientConfig);

        _logger.LogDebug("MAKC:MessageBroker:Connect:ProducerConfig {not}created", producerConfig != null ? string.Empty : "not ");

        if (producerConfig != null)
        {
          _producer = new ProducerBuilder<string, string>(producerConfig).Build();
        }

        _logger.LogDebug("MAKC:MessageBroker:Connect:Producer created");

        break;
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "MAKC:MessageBroker:Connect:Exception thrown");

        DisposeManagedResources();
      }

      await Task.Delay(_timeoutToRetry, cancellationToken).ConfigureAwait(false);
    }
  }

  /// <summary>
  /// Создать конфигурацию потребителя.
  /// </summary>
  /// <param name="clientConfig">Конфигурация клиента.</param>
  /// <returns>Конфигурация потребителя.</returns>
  protected abstract ConsumerConfig? CreateConsumerConfig(ClientConfig clientConfig);

  /// <summary>
  /// Создать конфигурацию поставщика.
  /// </summary>
  /// <param name="clientConfig">Конфигурация клиента.</param>
  /// <returns>Конфигурация поставщика.</returns>
  protected abstract ProducerConfig? CreateProducerConfig(ClientConfig clientConfig);

  /// <summary>
  /// Получить созданного потребителя.
  /// </summary>
  /// <returns>Потребитель.</returns>
  protected IConsumer<string, string> GetCreatedConsumer()
  {
    return Guard.Against.Null(_consumer);
  }

  /// <summary>
  /// Получить созданного поставщика.
  /// </summary>
  /// <returns>Поставщик.</returns>
  protected IProducer<string, string> GetCreatedProducer()
  {
    return Guard.Against.Null(_producer);
  }

  private void DisposeManagedResources()
  {
    _consumer?.Dispose();
    _consumer = null;

    _logger.LogDebug("MAKC:MessageBroker:DisposeManagedResources:Consumer disposed");

    _producer?.Dispose();
    _producer = null;

    _logger.LogDebug("MAKC:MessageBroker:DisposeManagedResources:Producer disposed");
  }

  #region IDisposable

  private bool _disposedValue;

  public void Dispose()
  {
    Dispose(disposing: true);

    GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!_disposedValue)
    {
      if (disposing)
      {
        DisposeManagedResources();
      }

      _disposedValue = true;
    }
  }

  #endregion IDisposable
}
