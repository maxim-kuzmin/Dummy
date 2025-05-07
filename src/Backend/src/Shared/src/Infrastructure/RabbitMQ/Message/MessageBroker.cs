using Makc.Dummy.Shared.Core.App.Config.Options.Sections.Infrastructure;

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

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="appConfigOptions">Параметры конфигурации приложения.</param>
  /// <param name="logger">Логгер.</param>
  public MessageBroker(AppConfigOptionsInfrastructureRabbitMQSection appConfigOptions, ILogger logger)
  {
    _logger = logger;

    _connectionFactory = new()
    {
      HostName = appConfigOptions.HostName,
      Password = appConfigOptions.Password,
      Port = appConfigOptions.Port,
      UserName = appConfigOptions.UserName
    };

    _timeoutToRetry = appConfigOptions.TimeoutInMillisecondsToRetry;
  }

  /// <inheritdoc/>
  public async Task Connect(CancellationToken cancellationToken)
  {
    while (!cancellationToken.IsCancellationRequested)
    {
      try
      {
        _connection = await CreateConnection(_connectionFactory, cancellationToken).ConfigureAwait(false);

        _logger.LogDebug("MAKC:MessageBroker:Connect:Connection created");

        _channel = await CreateChannel(_connection, cancellationToken).ConfigureAwait(false);

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
  /// Создать канал.
  /// </summary>
  /// <param name="connection">Подключение.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Канал.</returns>
  protected virtual Task<IChannel> CreateChannel(IConnection connection, CancellationToken cancellationToken)
  {
    return connection.CreateChannelAsync(null, cancellationToken);
  }

  /// <summary>
  /// Создать подключение.
  /// </summary>
  /// <param name="connectionFactory">Фабрика подключений.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Подключение.</returns>
  protected virtual Task<IConnection> CreateConnection(
    ConnectionFactory connectionFactory,
    CancellationToken cancellationToken)
  {
    return connectionFactory.CreateConnectionAsync(cancellationToken);
  }

  /// <summary>
  /// Получить созданный канал.
  /// </summary>
  /// <returns>Канал.</returns>
  protected IChannel GetCreatedChannel()
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
