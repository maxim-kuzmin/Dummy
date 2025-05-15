namespace Makc.Dummy.MicroserviceReader.Infrastructure.RabbitMQ.App.Message;

/// <summary>
/// Поставщик сообщений приложения.
/// </summary>
/// <param name="_funcToGetChannel">Функция получения канала.</param>
/// <param name="_logger">Логгер.</param>
public class AppMessageConsumer(Func<IChannel> _funcToGetChannel, ILogger _logger) : IAppMessageConsumer
{
  /// <inheritdoc/>
  public async ValueTask Subscribe(MessageReceiving receiving, CancellationToken cancellationToken)
  {
    const string queue = "Makc.Dummy.MicroserviceReader";

    string exchange = $"Makc.Dummy.{receiving.Sender}";

    var channel = _funcToGetChannel.Invoke();

    var exchangeTask = channel.ExchangeDeclareAsync(
      exchange: exchange,
      type: ExchangeType.Fanout,
      cancellationToken: cancellationToken);

    await exchangeTask.ConfigureAwait(false);

    _logger.LogDebug("MAKC:AppMessageConsumer:Subscribe:Exchange declared");

    var queueTask = channel.QueueDeclareAsync(
      queue: queue,
      durable: true,
      exclusive: false,
      autoDelete: false,
      arguments: null,
      cancellationToken: cancellationToken);

    await queueTask.ConfigureAwait(false);

    _logger.LogDebug("MAKC:AppMessageConsumer:Subscribe:Queue declared");

    var bindingTask = channel.QueueBindAsync(
      queue: queue,
      exchange: exchange,
      routingKey: string.Empty,
      cancellationToken: cancellationToken);

    await bindingTask.ConfigureAwait(false);

    _logger.LogDebug("MAKC:AppMessageConsumer:Subscribe:Queue bound to exchange");

    var qosTask = channel.BasicQosAsync(
      prefetchSize: 0,
      prefetchCount: 1,
      global: false,
      cancellationToken: cancellationToken);

    await qosTask.ConfigureAwait(false);

    var consumer = new AsyncEventingBasicConsumer(channel);

    _logger.LogDebug("MAKC:AppMessageConsumer:Subscribe:Consumer created");

    consumer.ReceivedAsync += async (model, ea) =>
    {
      byte[] body = ea.Body.ToArray();

      var message = Encoding.UTF8.GetString(body);

      await receiving.FuncToHandleMessage.Invoke(receiving.Sender, message, cancellationToken).ConfigureAwait(false);

      // here channel could also be accessed as ((AsyncEventingBasicConsumer)sender).Channel
      await channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false).ConfigureAwait(false);
    };

    var consumingTask = channel.BasicConsumeAsync(
      queue: queue,
      autoAck: false,
      consumer: consumer,
      cancellationToken: cancellationToken);

    _logger.LogDebug("MAKC:AppMessageConsumer:Subscribe:Consuming start");

    await consumingTask.ConfigureAwait(false);

    _logger.LogDebug("MAKC:AppMessageConsumer:Subscribe:Consuming end");
  }
}
