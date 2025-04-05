namespace Makc.Dummy.Writer.Infrastructure.RabbitMQ.App.Message;

/// <summary>
/// Поставщик сообщений приложения.
/// </summary>
/// <param name="options">Параметры.</param>
/// <param name="_logger">Логгер.</param>
public class AppMessageProducer(
  AppConfigOptionsRabbitMQSection? options,
  ILogger<AppMessageProducer> _logger) : MessageProducer(options, _logger), IAppMessageProducer
{
  /// <inheritdoc/>
  protected sealed override async Task Publish(
    IChannel channel,
    string receiver,
    string message,
    CancellationToken cancellationToken)
  {
    string exchange = $"Makc.Dummy.{receiver}";

    await channel.ExchangeDeclareAsync(
      exchange: exchange,
      type: ExchangeType.Fanout,
      cancellationToken: cancellationToken);

    var body = Encoding.UTF8.GetBytes(message);

    var properties = new BasicProperties
    {
      Persistent = true
    };

    await channel.BasicPublishAsync(
      exchange: exchange,
      routingKey: string.Empty,
      mandatory: true,      
      basicProperties: properties,
      body: body,
      cancellationToken: cancellationToken);

    _logger.LogInformation("MAKC:Published: {message}", message);
  }
}
