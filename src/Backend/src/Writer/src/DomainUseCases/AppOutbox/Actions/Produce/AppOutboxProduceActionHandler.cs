namespace Makc.Dummy.Writer.DomainUseCases.AppOutbox.Actions.Produce;

/// <summary>
/// Обработчик действия по по отправке в очередь сообщений о неопубликованных событиях и пометки их как опубликованные.
/// </summary>
/// <param name="_appMessageProducer">Поставщик сообщений приложения.</param>
/// <param name="_logger">Логгер.</param>
public class AppOutboxProduceActionHandler(
  IAppMessageProducer _appMessageProducer,
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
        _logger.LogDebug("MAKC:AppOutboxProduceActionHandler:Handle:Publish start");

        await _appMessageProducer.Publish(sending, cancellationToken);

        _logger.LogDebug("MAKC:AppOutboxProduceActionHandler:Handle:Publish completed:{message} to {receiver}:", sending.Message, sending.Receiver);
      }
      catch (OperationCanceledException)
      {
        _logger.LogDebug("MAKC:AppOutboxProduceActionHandler:Handle:Publish canceled:{message} to {receiver}", sending.Message, sending.Receiver);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "MAKC:AppOutboxProduceActionHandler:Handle:Exception");
      }

      await Task.Delay(timeoutToRepeat, cancellationToken);
    }

    return Result.NoContent();
  }
}
