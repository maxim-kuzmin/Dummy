namespace Makc.Dummy.Writer.Infrastructure.RabbitMQ.App.Message;

/// <summary>
/// Поставщик сообщений приложения.
/// </summary>
/// <param name="_funcToGetChannel">Функция получения канала.</param>
/// <param name="_logger">Логгер.</param>
public class AppMessageProducer(Func<IChannel> _funcToGetChannel, ILogger _logger) : IAppMessageProducer
{
  /// <inheritdoc/>
  public async ValueTask Publish(MessageSending sending, CancellationToken cancellationToken)
  {
    string exchange = $"Makc.Dummy.{sending.Receiver}";

    var channel = _funcToGetChannel.Invoke();

    var exchangeTask = channel.ExchangeDeclareAsync(
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

    var publishTask = channel.BasicPublishAsync(
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
