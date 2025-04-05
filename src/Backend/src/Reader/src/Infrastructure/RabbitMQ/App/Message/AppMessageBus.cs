namespace Makc.Dummy.Reader.Infrastructure.RabbitMQ.App.Message;

/// <summary>
/// Шина сообщений приложения.
/// </summary>
/// <param name="options">Параметры.</param>
/// <param name="_logger">Логгер.</param>
public class AppMessageBus(
  AppConfigOptionsRabbitMQSection? options,
  ILogger<AppMessageBus> _logger) : MessageBus(options, _logger), IAppMessageBus
{
  /// <inheritdoc/>
  protected override Task Publish(
    IChannel channel,
    string receiver,
    string message,
    CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  /// <inheritdoc/>
  protected sealed override async Task Subscribe(
    IChannel channel,
    string sender,
    MessageFuncToHandle funcToHandleMessage,
    CancellationToken cancellationToken)
  {    
    const string queue = "Makc.Dummy.Reader";

    string exchange = $"Makc.Dummy.{sender}";

    var exchangeTask = channel.ExchangeDeclareAsync(
      exchange: exchange,
      type: ExchangeType.Fanout,
      cancellationToken: cancellationToken);

    await exchangeTask.ConfigureAwait(false);

    var queueTask = channel.QueueDeclareAsync(
      queue: queue,
      durable: true,
      exclusive: false,
      autoDelete: false,
      arguments: null,
      cancellationToken: cancellationToken);

    await queueTask.ConfigureAwait(false);

    var bindingTask = channel.QueueBindAsync(
      queue: queue,
      exchange: exchange,
      routingKey: string.Empty,
      cancellationToken: cancellationToken);

    await bindingTask.ConfigureAwait(false);

    var qosTask = channel.BasicQosAsync(
      prefetchSize: 0,
      prefetchCount: 1,
      global: false,
      cancellationToken: cancellationToken);

    await qosTask.ConfigureAwait(false);

    var consumer = new AsyncEventingBasicConsumer(channel);

    consumer.ReceivedAsync += async (model, ea) =>
    {
      byte[] body = ea.Body.ToArray();

      var message = Encoding.UTF8.GetString(body);

      await funcToHandleMessage.Invoke(sender, message, cancellationToken).ConfigureAwait(false);      

      // here channel could also be accessed as ((AsyncEventingBasicConsumer)sender).Channel
      await channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false).ConfigureAwait(false);
    };

    var consumingTask = channel.BasicConsumeAsync(
      queue: queue,
      autoAck: false,
      consumer: consumer,
      cancellationToken: cancellationToken);

    await consumingTask.ConfigureAwait(false);
  }
}
