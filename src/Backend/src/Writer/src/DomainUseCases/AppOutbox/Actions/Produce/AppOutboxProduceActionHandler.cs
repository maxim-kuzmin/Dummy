namespace Makc.Dummy.Writer.DomainUseCases.AppOutbox.Actions.Produce;

/// <summary>
/// Обработчик действия по по отправке в очередь сообщений о неопубликованных событиях и пометки их как опубликованные.
/// </summary>
public class AppOutboxProduceActionHandler : ICommandHandler<AppOutboxProduceActionCommand, Result>
{
  /// <inheritdoc/>
  public Task<Result> Handle(AppOutboxProduceActionCommand request, CancellationToken cancellationToken)
  {
    return Task.FromResult(Result.NoContent());
  }
}
