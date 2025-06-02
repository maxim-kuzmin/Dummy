namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEventPayload.Services;

/// <summary>
/// Сервиса команд полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class AppIncomingEventPayloadCommandService(
  IAppDbNoSQLExecutionContext _appDbExecutionContext,
  IAppIncomingEventPayloadFactory _factory,
  IAppIncomingEventPayloadRepository _repository) : IAppIncomingEventPayloadCommandService
{
  /// <inheritdoc/>
  public async Task<AppCommandResultWithoutValue> Delete(
    AppIncomingEventPayloadDeleteCommand command,
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
  public async Task<Result> InsertList(
    AppIncomingEventPayloadInsertListCommand command,
    CancellationToken cancellationToken)
  {
    List<AppIncomingEventPayloadEntity> entities = new(command.Items.Count);

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

    await _repository.AddNotFoundByEventPayload(entities, cancellationToken).ConfigureAwait(false);

    return Result.Success();
  }

  /// <inheritdoc/>
  public async Task<AppCommandResultWithValue<AppIncomingEventPayloadSingleDTO>> Save(
    AppIncomingEventPayloadSaveCommand command,
    CancellationToken cancellationToken)
  {
    AppIncomingEventPayloadEntity? entity = null;

    if (command.IsUpdate)
    {
      string objectId = Guard.Against.NullOrWhiteSpace(command.ObjectId);

      entity = await _repository.GetByObjectId(objectId, cancellationToken).ConfigureAwait(false);

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

    var dto = entity.ToAppIncomingEventPayloadSingleDTO();

    AppCommandResultWithValue<AppIncomingEventPayloadSingleDTO> result = new(Result.Success(dto));

    result.Payloads.Add(payload);

    return result;
  }

  private AggregateResult<AppIncomingEventPayloadEntity> GetAggregateResultToDelete(AppIncomingEventPayloadEntity entity)
  {
    var aggregate = _factory.CreateAggregate(entity);

    return aggregate.GetResultToDelete();
  }

  private AggregateResult<AppIncomingEventPayloadEntity> GetAggregateResultToSave(
    AppIncomingEventPayloadEntity? entity,
    AppIncomingEventPayloadCommandDataSection data)
  {
    var aggregate = _factory.CreateAggregate(entity);

    var payload = data.Payload;

    aggregate.UpdateAppIncomingEventObjectId(data.AppIncomingEventObjectId);
    aggregate.UpdateData(payload.Data);
    aggregate.UpdateEntityConcurrencyTokenToDelete(payload.EntityConcurrencyTokenToDelete);
    aggregate.UpdateEntityConcurrencyTokenToInsert(payload.EntityConcurrencyTokenToInsert);
    aggregate.UpdateEntityId(payload.EntityId);
    aggregate.UpdateEntityName(payload.EntityName);
    aggregate.UpdatePosition(payload.Position);

    return entity != null ? aggregate.GetResultToUpdate() : aggregate.GetResultToCreate();
  }
}
