namespace Makc.Dummy.Reader.Infrastructure.RabbitMQ.App.Message;

/// <summary>
/// Поставщик сообщений приложения.
/// </summary>
/// <param name="_channel">Канал.</param>
/// <param name="_logger">Логгер.</param>
public class AppMessageConsumer(IChannel _channel, ILogger _logger) : IAppMessageConsumer
{
  /// <inheritdoc/>
  public async ValueTask Subscribe(MessageReceiving receiving, CancellationToken cancellationToken)
  {
    const string queue = "Makc.Dummy.Reader";

    string exchange = $"Makc.Dummy.{receiving.Sender}";

    var exchangeTask = _channel.ExchangeDeclareAsync(
      exchange: exchange,
      type: ExchangeType.Fanout,
      cancellationToken: cancellationToken);

    await exchangeTask.ConfigureAwait(false);

    _logger.LogDebug("MAKC:AppMessageConsumer:Subscribe:Exchange declared");

    var queueTask = _channel.QueueDeclareAsync(
      queue: queue,
      durable: true,
      exclusive: false,
      autoDelete: false,
      arguments: null,
      cancellationToken: cancellationToken);

    await queueTask.ConfigureAwait(false);

    _logger.LogDebug("MAKC:AppMessageConsumer:Subscribe:Queue declared");

    var bindingTask = _channel.QueueBindAsync(
      queue: queue,
      exchange: exchange,
      routingKey: string.Empty,
      cancellationToken: cancellationToken);

    await bindingTask.ConfigureAwait(false);

    _logger.LogDebug("MAKC:AppMessageConsumer:Subscribe:Queue bound to exchange");

    var qosTask = _channel.BasicQosAsync(
      prefetchSize: 0,
      prefetchCount: 1,
      global: false,
      cancellationToken: cancellationToken);

    await qosTask.ConfigureAwait(false);

    var consumer = new AsyncEventingBasicConsumer(_channel);

    _logger.LogDebug("MAKC:AppMessageConsumer:Subscribe:Consumer created");

    consumer.ReceivedAsync += async (model, ea) =>
    {
      byte[] body = ea.Body.ToArray();

      var message = Encoding.UTF8.GetString(body);

      await receiving.FuncToHandleMessage.Invoke(receiving.Sender, message, cancellationToken).ConfigureAwait(false);

      // here channel could also be accessed as ((AsyncEventingBasicConsumer)sender).Channel
      await _channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false).ConfigureAwait(false);
    };

    var consumingTask = _channel.BasicConsumeAsync(
      queue: queue,
      autoAck: false,
      consumer: consumer,
      cancellationToken: cancellationToken);

    _logger.LogDebug("MAKC:AppMessageConsumer:Subscribe:Consuming start");

    await consumingTask.ConfigureAwait(false);

    _logger.LogDebug("MAKC:AppMessageConsumer:Subscribe:Consuming end");
  }
}
