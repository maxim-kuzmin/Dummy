namespace Makc.Dummy.Writer.Infrastructure.RabbitMQ.App.Message;

/// <summary>
/// Шина сообщений приложения.
/// </summary>
/// <param name="_connection">Соединение.</param>
public class AppMessageBus(IConnection _connection) : IMessageBus
{
  /// <inheritdoc/>
  public async Task Publish<TMessage>(string subscriberId, TMessage message, CancellationToken cancellationToken)
  {
    using var channel = await _connection.CreateChannelAsync(null, cancellationToken);
  }

  /// <inheritdoc/>
  public async Task Subscribe<TMessage>(
    string subscriberId,
    Func<TMessage, CancellationToken, Task> onMessage,
    CancellationToken cancellationToken)
  {
    using var channel = await _connection.CreateChannelAsync(null, cancellationToken);
  }
}
