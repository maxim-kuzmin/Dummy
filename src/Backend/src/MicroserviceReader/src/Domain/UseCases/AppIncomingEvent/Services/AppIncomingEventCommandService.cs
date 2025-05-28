namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEvent.Services;

/// <summary>
/// Сервис команд входящего события приложения.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class AppIncomingEventCommandService(
  IAppDbNoSQLExecutionContext _appDbExecutionContext,
  IAppIncomingEventFactory _factory,
  IAppIncomingEventRepository _repository) : IAppIncomingEventCommandService
{
  /// <inheritdoc/>
  public async Task<AppCommandResultWithoutValue> Delete(
    AppIncomingEventDeleteCommand command,
    CancellationToken cancellationToken)
  {
    var entity = await _repository.GetByObjectId(command.ObjectId, cancellationToken).ConfigureAwait(false);

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
      await _repository.Delete(entity, cancellationToken).ConfigureAwait(false);
    }

    await _appDbExecutionContext.Execute(FuncToExecute, cancellationToken).ConfigureAwait(false);

    AppCommandResultWithoutValue result = new(Result.Success());

    result.Payloads.Add(payload);

    return result;
  }

  /// <inheritdoc/>
  public async Task<Result> InsertList(AppIncomingEventInsertListCommand command, CancellationToken cancellationToken)
  {
    List<AppIncomingEventEntity> entities = new(command.Items.Count);

    foreach (var item in command.Items)
    {
      var aggregateResult = GetAggregateResultToSave(null, item);

      var entity = aggregateResult.Entity;

      if (entity == null)
      {
        return Result.Invalid();
      }

      entities.Add(entity);
    }

    await _repository.AddNotFoundByEvent(entities, cancellationToken);

    return Result.Success();
  }

  /// <inheritdoc/>
  public async Task<AppCommandResultWithValue<AppIncomingEventSingleDTO>> Save(
    AppIncomingEventSaveCommand command,
    CancellationToken cancellationToken)
  {
    AppIncomingEventEntity? entity = null;

    if (command.IsUpdate)
    {
      entity = await _repository.GetByObjectId(command.ObjectId, cancellationToken).ConfigureAwait(false);

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
        await _repository.Update(entity, cancellationToken).ConfigureAwait(false);
      }
      else
      {
        entity = await _repository.Add(entity, cancellationToken).ConfigureAwait(false);

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
    AppIncomingEventCommandDataSection data)
  {
    var aggregate = _factory.CreateAggregate(entity);

    aggregate.UpdateEventId(data.EventId);
    aggregate.UpdateEventName(data.EventName);
    aggregate.UpdateLastLoadingAt(data.LastLoadingAt);
    aggregate.UpdateLastLoadingError(data.LastLoadingError);
    aggregate.UpdateLoadedAt(data.LoadedAt);
    aggregate.UpdatePayloadCount(data.PayloadCount);
    aggregate.UpdatePayloadTotalCount(data.PayloadTotalCount);
    aggregate.UpdateProcessedAt(data.ProcessedAt);

    return entity != null ? aggregate.GetResultToUpdate() : aggregate.GetResultToCreate();
  }
}
