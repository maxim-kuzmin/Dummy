namespace Makc.Dummy.Reader.DomainUseCases.AppInbox.Actions.Consume;

/// <summary>
/// Обработчик действия по получению из очереди сообщений о событиях и сохранению их в базе данных как необработанные.
/// </summary>
public class AppInboxConsumeActionHandler(
  ILogger<AppInboxConsumeActionHandler> _logger) : ICommandHandler<AppInboxConsumeActionCommand, Result>
{
  /// <inheritdoc/>
  public Task<Result> Handle(AppInboxConsumeActionCommand request, CancellationToken cancellationToken)
  {
    _logger.LogInformation("MAKC:Received: {message} from {sender}", request.Message, request.Sender);

    return Task.FromResult(Result.NoContent());
  }
}
