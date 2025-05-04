namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.Services;

/// <summary>
/// Сервис команд исходящего события приложения.
/// </summary>
public class AppOutgoingEventCommandService(
  IAppDbSQLExecutionContext _appDbExecutionContext,
  IAppOutgoingEventFactory _factory,
  IAppOutgoingEventRepository _repository) : IAppOutgoingEventCommandService
{
  /// <inheritdoc/>
  public async Task<AppCommandResultWithoutValue> Delete(
    AppOutgoingEventDeleteActionCommand command,
    CancellationToken cancellationToken)
  {
    var entity = await _repository.GetByIdAsync(command.Id, cancellationToken).ConfigureAwait(false);

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

  public async Task<AppCommandResultWithValue<AppOutgoingEventSingleDTO>> Save(
    AppOutgoingEventSaveActionCommand command,
    CancellationToken cancellationToken)
  {
    AppOutgoingEventEntity? entity = null;

    if (command.HasEntityBeingSavedAlreadyBeenCreated)
    {
      entity = await _repository.GetByIdAsync(command.Id, cancellationToken).ConfigureAwait(false);

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

    var dto = entity.ToAppOutgoingEventSingleDTO();

    AppCommandResultWithValue<AppOutgoingEventSingleDTO> result = new(Result.Success(dto));

    result.Payloads.Add(payload);

    return result;
  }

  private AggregateResult<AppOutgoingEventEntity> GetAggregateResultToDelete(AppOutgoingEventEntity entity)
  {
    var aggregate = _factory.CreateAggregate(entity);

    return aggregate.GetResultToDelete();
  }

  private AggregateResult<AppOutgoingEventEntity> GetAggregateResultToSave(
    AppOutgoingEventEntity? entity,
    AppOutgoingEventSaveActionCommand command)
  {
    var aggregate = _factory.CreateAggregate(entity);

    aggregate.UpdateName(command.Name);
    aggregate.UpdatePublishedAt(command.PublishedAt);

    return entity != null ? aggregate.GetResultToCreate() : aggregate.GetResultToUpdate();
  }
}
