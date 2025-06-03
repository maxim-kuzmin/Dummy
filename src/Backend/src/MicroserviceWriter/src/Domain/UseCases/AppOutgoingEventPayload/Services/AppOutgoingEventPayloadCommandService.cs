namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutgoingEventPayload.Services;

/// <summary>
/// Сервиса команд полезной нагрузки исходящего события приложения.
/// </summary>
public class AppOutgoingEventPayloadCommandService(
  IAppDbSQLExecutionContext _appDbExecutionContext,
  IAppOutgoingEventPayloadFactory _factory,
  IAppOutgoingEventPayloadRepository _repository) : IAppOutgoingEventPayloadCommandService
{
  /// <inheritdoc/>
  public async Task<AppCommandResultWithoutValue> Delete(
    AppOutgoingEventPayloadDeleteCommand command,
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
  public async Task<AppCommandResultWithValue<AppOutgoingEventPayloadSingleDTO>> Save(
    AppOutgoingEventPayloadSaveCommand command,
    CancellationToken cancellationToken)
  {
    AppOutgoingEventPayloadEntity? entity = null;

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

    var dto = entity.ToAppOutgoingEventPayloadSingleDTO();

    AppCommandResultWithValue<AppOutgoingEventPayloadSingleDTO> result = new(Result.Success(dto));

    result.Payloads.Add(payload);

    return result;
  }

  private AggregateResult<AppOutgoingEventPayloadEntity> GetAggregateResultToDelete(AppOutgoingEventPayloadEntity entity)
  {
    var aggregate = _factory.CreateAggregate(entity);

    return aggregate.GetResultToDelete();
  }

  private AggregateResult<AppOutgoingEventPayloadEntity> GetAggregateResultToSave(
    AppOutgoingEventPayloadEntity? entity,
    AppOutgoingEventPayloadCommandDataSection data)
  {
    var aggregate = _factory.CreateAggregate(entity);

    var payload = data.Payload;

    aggregate.UpdateAppOutgoingEventId(data.AppOutgoingEventId);
    aggregate.UpdateData(payload.Data);
    aggregate.UpdateEntityConcurrencyTokenToDelete(payload.EntityConcurrencyTokenToDelete);
    aggregate.UpdateEntityConcurrencyTokenToInsert(payload.EntityConcurrencyTokenToInsert);
    aggregate.UpdateEntityId(payload.EntityId);
    aggregate.UpdateEntityName(payload.EntityName);
    aggregate.UpdatePosition(payload.Position);

    return entity != null ? aggregate.GetResultToUpdate() : aggregate.GetResultToCreate();
  }
}
