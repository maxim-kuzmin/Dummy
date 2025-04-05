namespace Makc.Dummy.Shared.Infrastructure.RabbitMQ.Message;

/// <summary>
/// Потребитель сообщений приложения.
/// </summary>
public abstract class MessageConsumer : IMessageConsumer
{
  private readonly ConnectionFactory _connectionFactory;

  private readonly ILogger _logger;

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="options">Параметры.</param>
  /// <param name="logger">Логгер.</param>
  public MessageConsumer(AppConfigOptionsRabbitMQSection? options, ILogger logger)
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
  }

  /// <inheritdoc/>
  public Task Start(IEnumerable<MessageReceiving> receivings, CancellationToken cancellationToken)
  {
    Task.Run(() => Consume(receivings, cancellationToken), cancellationToken);

    return Task.CompletedTask;
  }

  /// <inheritdoc/>
  public async Task Consume(IEnumerable<MessageReceiving> receivings, CancellationToken cancellationToken)
  {
    while (!cancellationToken.IsCancellationRequested)
    {
      const int timeoutToRetry = 3000;

      try
      {
        using var connection = await _connectionFactory.CreateConnectionAsync(cancellationToken);

        _logger.LogInformation("MAKC:Connected");

        TaskCompletionSource shutdownCompletion = new();

        connection.ConnectionShutdownAsync += (e, a) =>
        {
          _logger.LogInformation("MAKC:Shutdown");

          if (!shutdownCompletion.Task.IsCompleted)
          {
            shutdownCompletion.SetResult();
          }

          return Task.CompletedTask;
        };

        using var channel = await connection.CreateChannelAsync(null, cancellationToken);

        foreach (var receiving in receivings)
        {
          await Subscribe(channel, receiving.Sender, receiving.FuncToHandleMessage, cancellationToken);
        }

        await shutdownCompletion.Task;
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "MAKC:Unknown");
      }

      await Task.Delay(timeoutToRetry, cancellationToken);
    }
  }

  /// <summary>
  /// Подписаться.
  /// </summary>
  /// <param name="channel">Канал.</param>
  /// <param name="sender">Отправитель.</param>
  /// <param name="funcToHandleMessage">Функция для обработки сообщения.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns></returns>
  protected abstract Task Subscribe(
    IChannel channel,
    string sender,
    MessageFuncToHandle funcToHandleMessage,
    CancellationToken cancellationToken);
}
