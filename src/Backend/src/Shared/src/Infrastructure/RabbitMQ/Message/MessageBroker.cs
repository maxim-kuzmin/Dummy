namespace Makc.Dummy.Shared.Infrastructure.RabbitMQ.Message;

/// <summary>
/// Брокер сообщений.
/// </summary>
/// <typeparam name="TMessageConsumer">Тип потребителя сообщений.</typeparam>
/// <typeparam name="TMessageProducer">Тип поставщика сообщений.</typeparam>
public abstract class MessageBroker<TMessageConsumer, TMessageProducer> : IMessageBroker, IDisposable
  where TMessageConsumer : IMessageConsumer
  where TMessageProducer : IMessageProducer  
{
  private readonly ConnectionFactory _connectionFactory;

  private readonly AppConfigOptionsMessageDirectionEnum _direction;

  private readonly ILogger _logger;

  private readonly int _timeoutToRetry;

  private IChannel? _channel;

  private IConnection? _connection;

  private bool _disposedValue;

  private TMessageConsumer? _messageConsumer;

  private TMessageProducer? _messageProducer;

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="options">Параметры.</param>
  /// <param name="logger">Логгер.</param>
  public MessageBroker(AppConfigOptionsRabbitMQSection? options, ILogger logger)
  {
    _logger = logger;

    Guard.Against.Null(options);

    _connectionFactory = new()
    {
      HostName = options.HostName,
      Password = options.Password,
      Port = options.Port,
      UserName = options.UserName
    };

    _direction = options.Direction;

    _timeoutToRetry = options.TimeoutInMillisecondsToRetry;
  }

  /// <inheritdoc/>
  public async Task Connect(CancellationToken cancellationToken)
  {
    while (!cancellationToken.IsCancellationRequested)
    {
      try
      {
        _connection = await _connectionFactory.CreateConnectionAsync(cancellationToken).ConfigureAwait(false);

        _logger.LogDebug("MAKC:MessageBroker:Connect:Connection created");

        _channel = await _connection.CreateChannelAsync(null, cancellationToken).ConfigureAwait(false);

        _logger.LogDebug("MAKC:MessageBroker:Connect:Channel created");

        bool shouldBeMessageConsumerCreated = _direction == AppConfigOptionsMessageDirectionEnum.Consumer
          ||
          _direction == AppConfigOptionsMessageDirectionEnum.Both;

        if (shouldBeMessageConsumerCreated)
        {
          _messageConsumer = CreateMessageConsumer(_channel);

          _logger.LogDebug("MAKC:MessageBroker:Connect:Message consumer created");
        }

        bool shouldBeMessageProducerCreated = _direction == AppConfigOptionsMessageDirectionEnum.Producer
          ||
          _direction == AppConfigOptionsMessageDirectionEnum.Both;

        if (shouldBeMessageProducerCreated)
        {
          _messageProducer = CreateMessageProducer(_channel);

          _logger.LogDebug("MAKC:MessageBroker:Connect:Message producer created");
        }

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

  /// <inheritdoc/>
  public ValueTask Publish(MessageSending sending, CancellationToken cancellationToken)
  {
    if (_messageProducer == null)
    {
      throw new NotImplementedException();
    }

    return _messageProducer.Publish(sending, cancellationToken);
  }

  /// <inheritdoc/>
  public ValueTask Subscribe(MessageReceiving receiving, CancellationToken cancellationToken)
  {
    if (_messageConsumer == null)
    {
      throw new NotImplementedException();
    }
    
    return _messageConsumer.Subscribe(receiving, cancellationToken);
  }

  /// <summary>
  /// Создать потребителя сообщений.
  /// </summary>
  /// <param name="channel">Канал.</param>
  /// <returns>Потребитель сообщений.</returns>
  protected abstract TMessageConsumer? CreateMessageConsumer(IChannel channel);

  /// <summary>
  /// Создать поставщика сообщений.
  /// </summary>
  /// <param name="channel">Канал.</param>
  /// <returns>Поставщик сообщений.</returns>
  protected abstract TMessageProducer? CreateMessageProducer(IChannel channel);

  private void DisposeManagedResources()
  {
    _channel?.Dispose();
    _channel = null;

    _logger.LogDebug("MAKC:MessageBroker:DisposeManagedResources:Channel disposed");

    _connection?.Dispose();
    _connection = null;

    _logger.LogDebug("MAKC:MessageBroker:DisposeManagedResources:Connection disposed");
  }

  #region IDisposable

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
