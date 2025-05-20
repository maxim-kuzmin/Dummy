namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.App.Message.Stubs;

/// <summary>
/// Заглушка потребителя сообщений приложения.
/// </summary>
public class AppMessageConsumerStub : IAppMessageConsumer
{
  /// <inheritdoc/>
  public ValueTask Subscribe(MessageReceiving receiving, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
