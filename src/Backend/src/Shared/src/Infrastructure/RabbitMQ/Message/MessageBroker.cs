namespace Makc.Dummy.Shared.Infrastructure.RabbitMQ.Message;

/// <summary>
/// Брокер сообщений.
/// </summary>
public abstract class MessageBroker : IMessageBroker, IDisposable
{
  private readonly ConnectionFactory _connectionFactory;

  private readonly ILogger _logger;

  private readonly int _timeoutToRetry;

  private IChannel? _channel;

  private IConnection? _connection;

  private bool _disposedValue;

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
  /// Получить канал.
  /// </summary>
  /// <returns>Канал.</returns>
  protected IChannel GetChannel()
  {
    return Guard.Against.Null(_channel);
  }

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
