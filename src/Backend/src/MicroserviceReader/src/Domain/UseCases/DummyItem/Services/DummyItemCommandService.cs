namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.DummyItem.Services;

/// <summary>
/// Сервис команд фиктивного предмета.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class DummyItemCommandService(
  IAppDbNoSQLExecutionContext _appDbExecutionContext,
  IDummyItemFactory _factory,
  IDummyItemRepository _repository) : IDummyItemCommandService
{
  /// <inheritdoc/>
  public async Task<AppCommandResultWithoutValue> Delete(
    DummyItemDeleteCommand command,
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
  public async Task<AppCommandResultWithValue<DummyItemSingleDTO>> Save(
    DummyItemSaveCommand command,
    CancellationToken cancellationToken)
  {
    DummyItemEntity? entity = null;

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

    var dto = entity.ToDummyItemSingleDTO();

    AppCommandResultWithValue<DummyItemSingleDTO> result = new(Result.Success(dto));

    result.Payloads.Add(payload);

    return result;
  }

  private AggregateResult<DummyItemEntity> GetAggregateResultToDelete(DummyItemEntity entity)
  {
    var aggregate = _factory.CreateAggregate(entity);

    return aggregate.GetResultToDelete();
  }

  private AggregateResult<DummyItemEntity> GetAggregateResultToSave(
    DummyItemEntity? entity,
    DummyItemCommandDataSection data)
  {
    var aggregate = _factory.CreateAggregate(entity);

    aggregate.UpdateConcurrencyToken(data.ConcurrencyToken);
    aggregate.UpdateId(data.Id);
    aggregate.UpdateName(data.Name);

    return entity != null ? aggregate.GetResultToUpdate() : aggregate.GetResultToCreate();
  }
}
