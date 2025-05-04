namespace Makc.Dummy.Writer.DomainUseCases.DummyItem.Services;

/// <summary>
/// Сервис команд фиктивного предмета.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_appOutboxCommandService">Сервис команд исходящего сообщения приложения.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class DummyItemCommandService(
  IAppDbSQLExecutionContext _appDbExecutionContext,
  IAppOutboxCommandService _appOutboxCommandService,
  IDummyItemFactory _factory,
  IDummyItemEntityRepository _repository) : IDummyItemCommandService
{
  /// <inheritdoc/>
  public async Task<AppCommandResultWithoutValue> Delete(
    DummyItemDeleteActionCommand command,
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
  public Task<AppCommandResultWithoutValue> OnEntityChanged(
    IEnumerable<AppEventPayloadWithDataAsDictionary> payloads,
    CancellationToken cancellationToken)
  {
    var command = AppEventNameEnum.DummyItemChanged.ToAppOutboxSaveActionCommand(payloads);

    return _appOutboxCommandService.Save(command, cancellationToken);
  }

  public async Task<AppCommandResultWithValue<DummyItemSingleDTO>> Save(
    DummyItemSaveActionCommand command,
    CancellationToken cancellationToken)
  {
    DummyItemEntity? entity = null;

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
    DummyItemSaveActionCommand command)
  {
    var aggregate = _factory.CreateAggregate(entity);

    aggregate.UpdateName(command.Name);

    return entity != null ? aggregate.GetResultToCreate() : aggregate.GetResultToUpdate();
  }
}
