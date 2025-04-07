namespace Makc.Dummy.Writer.DomainUseCases.AppOutbox.Actions.Produce;

/// <summary>
/// Обработчик действия по по отправке в очередь сообщений о неопубликованных событиях и пометки их как опубликованные.
/// </summary>
/// <param name="_appMessageBus">Шина сообщений приложения.</param>
/// <param name="_logger">Логгер.</param>
public class AppOutboxProduceActionHandler(
  IAppMessageBus _appMessageBus,
  ILogger<AppOutboxProduceActionHandler> _logger) : ICommandHandler<AppOutboxProduceActionCommand, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(AppOutboxProduceActionCommand request, CancellationToken cancellationToken)
  {
    const int timeoutToRepeat = 3000;

    while (!cancellationToken.IsCancellationRequested)
    {
      MessageSending sending = new(AppEventNameEnum.DummyItemChanged.ToString(), DateTimeOffset.Now.ToString());

      try
      {        
        _logger.LogDebug("MAKC:Sending:Publish:Start");

        await _appMessageBus.Publish(sending, cancellationToken);

        _logger.LogDebug("MAKC:Sending:Publish:End");

        await sending.CompletionTask;

        _logger.LogDebug("MAKC:Sending:{message} to {receiver}:Completed:{status}", sending.Message, sending.Receiver, sending.CompletionTask.Status);
      }
      catch (OperationCanceledException)
      {
        _logger.LogDebug("MAKC:Sending:{message} to {receiver}:Canceled", sending.Message, sending.Receiver);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "MAKC:Sending:Unknown");
      }

      await Task.Delay(timeoutToRepeat, cancellationToken);
    }

    return Result.NoContent();
  }
}
