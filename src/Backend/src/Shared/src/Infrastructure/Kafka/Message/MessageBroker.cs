namespace Makc.Dummy.Shared.Infrastructure.Kafka.Message;

/// <summary>
/// Брокер сообщений.
/// </summary>
/// <param name="_clientConfig">Конфигурация клиента.</param>
/// <param name="_timeoutToRetry">
/// Таймаут в миллисекундах для повторного подключения к брокеру сообщений в случае неудачи.
/// </param>
/// <param name="_logger">Логгер.</param>
public abstract class MessageBroker(int _timeoutToRetry, ILogger _logger) : IMessageBroker, IDisposable
{
  private IConsumer<string, string>? _consumer;

  private IProducer<string, string>? _producer;

  public async Task Connect(CancellationToken cancellationToken)
  {
    while (!cancellationToken.IsCancellationRequested)
    {
      try
      {
        var consumerConfig = GetConsumerConfig();

        _logger.LogDebug("MAKC:MessageBroker:Connect:ConsumerConfig {not}created", consumerConfig != null ? string.Empty : "not ");

        if (consumerConfig != null)
        {
          _consumer = new ConsumerBuilder<string, string>(consumerConfig)
            .SetPartitionsRevokedHandler((_, _) =>
            {
              // https://docs.confluent.io/kafka-clients/dotnet/current/overview.html#committing-during-a-rebalance 
              _logger.LogDebug("MAKC:MessageBroker:Connect:PartitionsRevokedHandler called");
            }).Build();

          _logger.LogDebug("MAKC:MessageBroker:Connect:Consumer created");
        }

        var producerConfig = GetProducerConfig();

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
  /// Получить конфигурацию потребителя.
  /// </summary>
  /// <returns>Конфигурация потребителя.</returns>
  protected abstract ConsumerConfig? GetConsumerConfig();

  /// <summary>
  /// Получить конфигурацию поставщика.
  /// </summary>
  /// <returns>Конфигурация поставщика.</returns>
  protected abstract ProducerConfig? GetProducerConfig();

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
