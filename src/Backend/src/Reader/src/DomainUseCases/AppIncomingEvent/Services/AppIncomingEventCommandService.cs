namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEvent.Services;

/// <summary>
/// Сервис команд входящего события приложения.
/// </summary>
public class AppIncomingEventCommandService(
  IAppDbNoSQLExecutionContext _appDbExecutionContext,
  IAppIncomingEventFactory _factory,
  IAppIncomingEventRepository _repository) : IAppIncomingEventCommandService
{
  /// <inheritdoc/>
  public async Task<AppCommandResultWithoutValue> Delete(
    AppIncomingEventDeleteActionCommand command,
    CancellationToken cancellationToken)
  {
    var entity = await _repository.GetByObjectIdAsync(command.ObjectId, cancellationToken).ConfigureAwait(false);

    if (entity == null)
    {
      return new(Result.NotFound());
    }

    var aggregateResult = GetAggregateResultToDelete(entity);

    entity = aggregateResult.Entity;

    if (entity == null)
    {
      return new(Result.Invalid());
    }

    var validationErrors = aggregateResult.ToValidationErrors();

    if (validationErrors.Count > 0)
    {
      return new(Result.Invalid(validationErrors));
    }

    var payload = aggregateResult.Payload;

    if (payload == null)
    {
      return new(Result.Forbidden());
    }

    async Task FuncToExecute(CancellationToken cancellationToken)
    {
      await _repository.DeleteAsync(entity, cancellationToken).ConfigureAwait(false);
    }

    await _appDbExecutionContext.Execute(FuncToExecute, cancellationToken).ConfigureAwait(false);

    AppCommandResultWithoutValue result = new(Result.Success());

    result.Payloads.Add(payload);

    return result;
  }

  public async Task<AppCommandResultWithValue<AppIncomingEventSingleDTO>> Save(
    AppIncomingEventSaveActionCommand command,
    CancellationToken cancellationToken)
  {
    AppIncomingEventEntity? entity = null;

    if (command.HasEntityBeingSavedAlreadyBeenCreated)
    {
      entity = await _repository.GetByObjectIdAsync(command.ObjectId, cancellationToken).ConfigureAwait(false);

      if (entity == null)
      {
        return new(Result.NotFound());
      }
    }

    var aggregateResult = GetAggregateResultToSave(entity, command);

    entity = aggregateResult.Entity;

    if (entity == null)
    {
      return new(Result.Invalid());
    }

    var validationErrors = aggregateResult.ToValidationErrors();

    if (validationErrors.Count > 0)
    {
      return new(Result.Invalid(validationErrors));
    }

    var payload = aggregateResult.Payload;

    if (payload == null)
    {
      return new(Result.Forbidden());
    }

    async Task FuncToExecute(CancellationToken cancellationToken)
    {
      if (command.HasEntityBeingSavedAlreadyBeenCreated)
      {
        await _repository.UpdateAsync(entity, cancellationToken).ConfigureAwait(false);
      }
      else
      {
        entity = await _repository.AddAsync(entity, cancellationToken).ConfigureAwait(false);

        payload.EntityId = entity.GetPrimaryKeyAsString();
      }        
    }

    await _appDbExecutionContext.Execute(FuncToExecute, cancellationToken).ConfigureAwait(false);

    var dto = entity.ToAppIncomingEventSingleDTO();

    AppCommandResultWithValue<AppIncomingEventSingleDTO> result = new(Result.Success(dto));

    result.Payloads.Add(payload);

    return result;
  }

  private AggregateResult<AppIncomingEventEntity> GetAggregateResultToDelete(AppIncomingEventEntity entity)
  {
    var aggregate = _factory.CreateAggregate(entity);

    return aggregate.GetResultToDelete();
  }

  private AggregateResult<AppIncomingEventEntity> GetAggregateResultToSave(
    AppIncomingEventEntity? entity,
    AppIncomingEventSaveActionCommand command)
  {
    var aggregate = _factory.CreateAggregate(entity);

    aggregate.UpdateEventId(command.EventId);
    aggregate.UpdateEventName(command.EventName);
    aggregate.UpdateLastLoadingAt(command.LastLoadingAt);
    aggregate.UpdateLastLoadingError(command.LastLoadingError);
    aggregate.UpdateLoadedAt(command.LoadedAt);
    aggregate.UpdatePayloadCount(command.PayloadCount);
    aggregate.UpdatePayloadTotalCount(command.PayloadTotalCount);
    aggregate.UpdateProcessedAt(command.ProcessedAt);

    return entity != null ? aggregate.GetResultToUpdate() : aggregate.GetResultToCreate();
  }
}
