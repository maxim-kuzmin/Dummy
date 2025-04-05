namespace Makc.Dummy.Writer.Infrastructure.RabbitMQ.App.Message;

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
  protected sealed override async Task Publish(
    IChannel channel,
    string receiver,
    string message,
    CancellationToken cancellationToken)
  {
    string exchange = $"Makc.Dummy.{receiver}";

    var exchangeTask = channel.ExchangeDeclareAsync(
      exchange: exchange,
      type: ExchangeType.Fanout,
      cancellationToken: cancellationToken);

    await exchangeTask.ConfigureAwait(false);

    var body = Encoding.UTF8.GetBytes(message);

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

    _logger.LogInformation("MAKC:Published: {message}", message);
  }

  /// <inheritdoc/>
  protected override Task Subscribe(
    IChannel channel,
    string sender,
    MessageFuncToHandle funcToHandleMessage,
    CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
