namespace Makc.Dummy.Writer.DomainUseCases.AppOutbox.Actions.Save;

/// <summary>
/// Обработчик действия по сохранению в базе данных события приложения, помеченного как неопубликованное.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_mediator">Медиатор.</param>
public class AppOutboxSaveActionHandler(
  IAppDbExecutionContext _appDbExecutionContext,
  IMediator _mediator) :
  ICommandHandler<AppOutboxSaveActionCommand, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(AppOutboxSaveActionCommand request, CancellationToken cancellationToken)
  {
    async Task FuncToExecute(CancellationToken cancellationToken)
    {
      var appEvent = await CreateAppEvent(request, cancellationToken).ConfigureAwait(false);

      foreach (var payload in request.AppEventPayloads)
      {
        await CreateAppEventPayload(appEvent.Id, payload, cancellationToken).ConfigureAwait(false);
      }
    }

    await _appDbExecutionContext.ExecuteInTransaction(FuncToExecute, cancellationToken).ConfigureAwait(false);

    return Result.NoContent();
  }

  private async Task<AppEventSingleDTO> CreateAppEvent(
    AppOutboxSaveActionCommand request,
    CancellationToken cancellationToken)
  {
    AppEventCreateActionCommand command = new(false, request.AppEventName.ToString());

    var result = await _mediator.Send(command, cancellationToken).ConfigureAwait(false);

    return result.Value;
  }

  private async Task<AppEventPayloadSingleDTO> CreateAppEventPayload(
    long appEventId,
    object payload,
    CancellationToken cancellationToken)
  {
    AppEventPayloadCreateActionCommand command = new(appEventId, JsonSerializer.Serialize(payload));

    var result = await _mediator.Send(command, cancellationToken).ConfigureAwait(false);

    return result.Value;
  }
}
