namespace Makc.Dummy.Writer.Infrastructure.RabbitMQ.App.Message.Bus;

/// <summary>
/// Фабрика шины сообщений приложения.
/// </summary>
public class AppMessageBusFactory : IAppMessageBusFactory
{
  private readonly ConnectionFactory _connectionFactory;
  private readonly Lock _locker = new();

  private IConnection? _connection = null;
  private bool _disposedValue;

  public AppMessageBusFactory(AppConfigOptionsRabbitMQSection options)
  {
    _connectionFactory = new ConnectionFactory
    {
      HostName = options.HostName,
      Password = options.Password,
      Port = options.Port,
      UserName = options.UserName,
    };
  }

  // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
  // ~AppContext()
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

  /// <summary>
  /// Создать шину приложения.
  /// </summary>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Шина приложения.</returns>
  public Task<IMessageBus> CreateMessageBus(CancellationToken cancellationToken)
  {
    var connection = GetConnection(cancellationToken);

    IMessageBus result = new AppMessageBus(connection);

    return Task.FromResult(result);
  }

  /// <inheritdoc/>
  protected virtual void Dispose(bool disposing)
  {
    if (!_disposedValue)
    {
      if (disposing)
      {
        _connection?.Dispose();
      }

      // TODO: free unmanaged resources (unmanaged objects) and override finalizer
      // TODO: set large fields to null
      _disposedValue = true;
    }
  }

  private IConnection GetConnection(CancellationToken cancellationToken)
  {
    lock (_locker)
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
