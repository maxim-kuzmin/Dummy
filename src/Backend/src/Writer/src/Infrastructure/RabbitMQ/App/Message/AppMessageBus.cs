namespace Makc.Dummy.Writer.Infrastructure.RabbitMQ.App.Message;

/// <summary>
/// Шина сообщений приложения.
/// </summary>
public class AppMessageBus : IAppMessageBus
{
  private readonly ConcurrentDictionary<string, IChannel> _channelLookup = [];
  private readonly ConnectionFactory _connectionFactory;
  private readonly Lock _connectionLocker = new();

  private IConnection? _connection = null;
  private bool _disposedValue;

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="options">Параметры.</param>
  public AppMessageBus(AppConfigOptionsRabbitMQSection options)
  {
    _connectionFactory = new()
    {
      HostName = options.HostName,
      Password = options.Password,
      Port = options.Port,
      UserName = options.UserName,
    };
  }

  // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
  // ~AppMessageBus()
  // {
  //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
  //     Dispose(disposing: false);
  // }

  /// <inheritdoc/>
  public void Dispose()
  {
    // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    Dispose(disposing: true);
    GC.SuppressFinalize(this);
  }

  /// <inheritdoc/>
  public async Task Publish<TMessage>(string subscriberId, TMessage message, CancellationToken cancellationToken)
  {
    var connection = GetConnection(cancellationToken);

    using var channel = await connection.CreateChannelAsync(null, cancellationToken);
  }

  /// <inheritdoc/>
  public async Task Subscribe<TMessage>(
    string subscriberId,
    Func<TMessage, CancellationToken, Task> onMessage,
    CancellationToken cancellationToken)
  {
    var connection = GetConnection(cancellationToken);

    using var channel = await connection.CreateChannelAsync(null, cancellationToken);
  }

  /// <inheritdoc/>
  protected virtual void Dispose(bool disposing)
  {
    if (!_disposedValue)
    {
      if (disposing)
      {
        lock (_connectionLocker)
        {
          foreach (var channel in _channelLookup.Values)
          {
            channel.Dispose();
          }

          _connection?.Dispose();
        }
      }

      // TODO: free unmanaged resources (unmanaged objects) and override finalizer
      // TODO: set large fields to null
      _disposedValue = true;
    }
  }

  private IConnection GetConnection(CancellationToken cancellationToken)
  {
    lock (_connectionLocker)
    {
      if (_connection != null && !_connection.IsOpen)
      {
        _connection.Dispose();

        _connection = null;
      }

      _connection ??= _connectionFactory.CreateConnectionAsync(cancellationToken).Result;

      return _connection;
    }
  }
}
