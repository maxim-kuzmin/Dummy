namespace Makc.Dummy.Writer.Infrastructure.Kafka.App.Message;

/// <summary>
/// Поставщик сообщений приложения.
/// </summary>
/// <param name="_funcToGetProducer">Функция получения поставщика.</param>
/// <param name="_logger">Логгер.</param>
public class AppMessageProducer(
  Func<IProducer<string, string>> _funcToGetProducer,
  ILogger _logger) : IAppMessageProducer
{
  /// <inheritdoc/>
  public async ValueTask Publish(MessageSending sending, CancellationToken cancellationToken)
  {
    string topic = $"Makc.Dummy.{sending.Receiver}";

    var producer = _funcToGetProducer.Invoke();

    Message<string, string> message = new() { Value = sending.Message };

    await producer.ProduceAsync(topic, message, cancellationToken).ConfigureAwait(false);

    _logger.LogDebug("MAKC:AppMessageProducer:Publish:Message published:{message} to {receiver}", sending.Message, sending.Receiver);
  }
}
