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
      try
      {
        MessageSending sending = new(AppEventNameEnum.DummyItemChanged.ToString(), DateTimeOffset.Now.ToString());

        await _appMessageBus.Publish(sending, cancellationToken);

        await sending.CompletionTask;
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "MAKC:Sending");
      }

      await Task.Delay(timeoutToRepeat, cancellationToken);
    }

    return Result.NoContent();
  }
}
