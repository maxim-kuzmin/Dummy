namespace Makc.Dummy.Writer.Infrastructure.RabbitMQ.App.Message;

/// <summary>
/// Поставщик сообщений приложения.
/// </summary>
/// <param name="_channel">Канал.</param>
/// <param name="_logger">Логгер.</param>
public class AppMessageProducer(IChannel _channel, ILogger _logger) : IAppMessageProducer
{
  /// <inheritdoc/>
  public async ValueTask Publish(MessageSending sending, CancellationToken cancellationToken)
  {
    string exchange = $"Makc.Dummy.{sending.Receiver}";

    var exchangeTask = _channel.ExchangeDeclareAsync(
      exchange: exchange,
      type: ExchangeType.Fanout,
      cancellationToken: cancellationToken);

    await exchangeTask.ConfigureAwait(false);

    _logger.LogDebug("MAKC:AppMessageProducer:Publish:Exchange declared");

    var body = Encoding.UTF8.GetBytes(sending.Message);

    var properties = new BasicProperties
    {
      Persistent = true
    };

    var publishTask = _channel.BasicPublishAsync(
      exchange: exchange,
      routingKey: string.Empty,
      mandatory: true,
      basicProperties: properties,
      body: body,
      cancellationToken: cancellationToken);

    await publishTask.ConfigureAwait(false);

    _logger.LogDebug("MAKC:AppMessageProducer:Publish:Message published:{message} to {receiver}", sending.Message, sending.Receiver);
  }
}
