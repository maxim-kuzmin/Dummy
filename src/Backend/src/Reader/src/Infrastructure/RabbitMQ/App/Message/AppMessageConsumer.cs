namespace Makc.Dummy.Reader.Infrastructure.RabbitMQ.App.Message;

/// <summary>
/// Потребитель сообщений приложения.
/// </summary>
/// <param name="options">Параметры.</param>
/// <param name="_logger">Логгер.</param>
public class AppMessageConsumer(
  AppConfigOptionsRabbitMQSection? options,
  ILogger<AppMessageConsumer> _logger) : MessageConsumer(options, _logger), IAppMessageConsumer
{
  /// <inheritdoc/>
  protected sealed override async Task Subscribe(
    IChannel channel,
    string sender,
    MessageFuncToHandle funcToHandleMessage,
    CancellationToken cancellationToken)
  {    
    const string queue = "Makc.Dummy.Reader";

    string exchange = $"Makc.Dummy.{sender}";

    await channel.ExchangeDeclareAsync(
      exchange: exchange,
      type: ExchangeType.Fanout,
      cancellationToken: cancellationToken);

    await channel.QueueDeclareAsync(
      queue: queue,
      durable: true,
      exclusive: false,
      autoDelete: false,
      arguments: null,
      cancellationToken: cancellationToken);

    await channel.QueueBindAsync(
      queue: queue,
      exchange: exchange,
      routingKey: string.Empty,
      cancellationToken: cancellationToken);

    await channel.BasicQosAsync(
      prefetchSize: 0,
      prefetchCount: 1,
      global: false,
      cancellationToken: cancellationToken);

    var consumer = new AsyncEventingBasicConsumer(channel);

    consumer.ReceivedAsync += async (model, ea) =>
    {
      byte[] body = ea.Body.ToArray();

      var message = Encoding.UTF8.GetString(body);

      await funcToHandleMessage.Invoke(sender, message, cancellationToken);      

      // here channel could also be accessed as ((AsyncEventingBasicConsumer)sender).Channel
      await channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
    };

    await channel.BasicConsumeAsync(
      queue: queue,
      autoAck: false,
      consumer: consumer,
      cancellationToken: cancellationToken);
  }
}
