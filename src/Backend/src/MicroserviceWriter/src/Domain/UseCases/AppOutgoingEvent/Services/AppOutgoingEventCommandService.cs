namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent.Services;

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
    AppOutgoingEventDeleteCommand command,
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

  /// <inheritdoc/>
  public async Task<AppCommandResultWithValue<AppOutgoingEventSingleDTO>> Save(
    AppOutgoingEventSaveCommand command,
    CancellationToken cancellationToken)
  {
    AppOutgoingEventEntity? entity = null;

    if (command.IsUpdate)
    {
      entity = await _repository.GetByIdAsync(command.Id, cancellationToken).ConfigureAwait(false);

      if (entity == null)
      {
        return new(Result.NotFound());
      }
    }

    var aggregateResult = GetAggregateResultToSave(entity, command.Data);

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
      if (command.IsUpdate)
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

  /// <inheritdoc/>
  public Task MarkAsPublished(AppOutgoingEventMarkAsPublishedCommand command, CancellationToken cancellationToken)
  {
    return _repository.UpdatePublishedAt(command, cancellationToken);
  }

  private AggregateResult<AppOutgoingEventEntity> GetAggregateResultToDelete(AppOutgoingEventEntity entity)
  {
    var aggregate = _factory.CreateAggregate(entity);

    return aggregate.GetResultToDelete();
  }

  private AggregateResult<AppOutgoingEventEntity> GetAggregateResultToSave(
    AppOutgoingEventEntity? entity,
    AppOutgoingEventCommandDataSection data)
  {
    var aggregate = _factory.CreateAggregate(entity);

    aggregate.UpdateName(data.Name);
    aggregate.UpdatePublishedAt(data.PublishedAt);

    return entity != null ? aggregate.GetResultToUpdate() : aggregate.GetResultToCreate();
  }
}
