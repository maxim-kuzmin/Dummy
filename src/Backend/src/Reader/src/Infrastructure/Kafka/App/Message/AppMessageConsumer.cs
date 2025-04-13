namespace Makc.Dummy.Reader.Infrastructure.Kafka.App.Message;

public class AppMessageConsumer(
  Func<IConsumer<string, string>> _funcToGetConsumer,
  ILogger _logger) : IAppMessageConsumer
{
  /// <inheritdoc/>
  public async ValueTask Subscribe(MessageReceiving receiving, CancellationToken cancellationToken)
  {
    string topic = $"Makc.Dummy.{receiving.Sender}";

    var consumer = _funcToGetConsumer.Invoke();

    consumer.Subscribe(topic);

    _logger.LogDebug("MAKC:AppMessageConsumer:Subscribe:Start");

    while (!cancellationToken.IsCancellationRequested)
    {
      try
      {
        var consumeResult = consumer.Consume(cancellationToken);

        string message = consumeResult.Message.Value;

        await receiving.FuncToHandleMessage.Invoke(receiving.Sender, message, cancellationToken).ConfigureAwait(false);

        consumer.StoreOffset(consumeResult); // https://docs.confluent.io/kafka-clients/dotnet/current/overview.html#store-offsets
      }
      catch (OperationCanceledException)
      {
        _logger.LogDebug("MAKC:AppMessageConsumer:Consume of {sender} canceled", receiving.Sender);

        break;
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "MAKC:AppMessageConsumer:Subscribe:Exception");
      }
    }

    _logger.LogDebug("MAKC:AppMessageConsumer:Subscribe:End");
  }
}
