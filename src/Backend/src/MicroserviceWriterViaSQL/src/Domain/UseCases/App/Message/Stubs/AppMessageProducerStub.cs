﻿namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.UseCases.App.Message.Stubs;

/// <summary>
/// Заглушка поставщика сообщений приложения.
/// </summary>
public class AppMessageProducerStub : IAppMessageProducer
{
  /// <inheritdoc/>
  public ValueTask Publish(MessageSending sending, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
