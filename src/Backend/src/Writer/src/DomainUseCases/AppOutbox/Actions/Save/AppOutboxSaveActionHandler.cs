namespace Makc.Dummy.Writer.DomainUseCases.AppOutbox.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению в базе данных исходящего события приложения, помеченного как неопубликованное.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_mediator">Медиатор.</param>
public class AppOutboxSaveActionHandler(
  IAppDbSQLExecutionContext _appDbExecutionContext,
  IMediator _mediator) :
  ICommandHandler<AppOutboxSaveActionCommand, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(AppOutboxSaveActionCommand request, CancellationToken cancellationToken)
  {
    async Task FuncToExecute(CancellationToken cancellationToken)
    {
      var appOutgoingEvent = await CreateAppOutgoingEvent(request, cancellationToken).ConfigureAwait(false);

      foreach (var payload in request.AppEventPayloads)
      {
        await CreateAppOutgoingEventPayload(appOutgoingEvent.Id, payload, cancellationToken).ConfigureAwait(false);
      }
    }

    await _appDbExecutionContext.ExecuteInTransaction(FuncToExecute, cancellationToken).ConfigureAwait(false);

    return Result.NoContent();
  }

  private async Task<AppOutgoingEventSingleDTO> CreateAppOutgoingEvent(
    AppOutboxSaveActionCommand request,
    CancellationToken cancellationToken)
  {
    AppOutgoingEventCreateActionCommand command = new(false, request.AppEventName.ToString());

    var result = await _mediator.Send(command, cancellationToken).ConfigureAwait(false);

    return result.Value;
  }

  private async Task<AppOutgoingEventPayloadSingleDTO> CreateAppOutgoingEventPayload(
    long appOutgoingEventId,
    AppEventPayload payload,
    CancellationToken cancellationToken)
  {
    AppOutgoingEventPayloadCreateActionCommand command = new(appOutgoingEventId, payload);

    var result = await _mediator.Send(command, cancellationToken).ConfigureAwait(false);

    return result.Value;
  }
}
