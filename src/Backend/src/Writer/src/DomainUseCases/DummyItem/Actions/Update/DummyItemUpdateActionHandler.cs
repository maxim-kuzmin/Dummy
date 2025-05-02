namespace Makc.Dummy.Writer.DomainUseCases.DummyItem.Actions.Update;

/// <summary>
/// Обработчик действия по обновлению фиктивного предмета.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
/// <param name="_service">Сервис.</param>
public class DummyItemUpdateActionHandler(
  IAppDbSQLExecutionContext _appDbExecutionContext,
  IDummyItemFactory _factory,
  IDummyItemEntityRepository _repository,
  IDummyItemCommandService _service) :
  ICommandHandler<DummyItemUpdateActionCommand, Result<DummyItemSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<DummyItemSingleDTO>> Handle(
    DummyItemUpdateActionCommand request,
    CancellationToken cancellationToken)
  {
    var entity = await _repository.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

    if (entity == null)
    {
      return Result.NotFound();
    }

    var aggregateResult = GetAggregateResult(entity, request);

    entity = aggregateResult.Entity;

    if (entity == null)
    {
      return Result.Invalid();
    }

    var validationErrors = aggregateResult.ToValidationErrors();

    if (validationErrors.Count > 0)
    {
      return Result.Invalid(validationErrors);
    }

    var payload = aggregateResult.Payload;

    if (payload == null)
    {
      return Result.Forbidden();
    }

    async Task FuncToExecute(CancellationToken cancellationToken)
    {
      await _repository.UpdateAsync(entity, cancellationToken).ConfigureAwait(false);

      await _service.OnEntityChanged(payload, cancellationToken).ConfigureAwait(false);
    }

    await _appDbExecutionContext.ExecuteInTransaction(FuncToExecute, cancellationToken).ConfigureAwait(false);

    var dto = entity.ToDummyItemSingleDTO();

    return Result.Success(dto);
  }

  private AggregateResult<DummyItemEntity> GetAggregateResult(
    DummyItemEntity entity,
    DummyItemUpdateActionCommand command)
  {
    var aggregate = _factory.CreateAggregate(entity);

    aggregate.UpdateName(command.Name);

    return aggregate.GetResultToUpdate();
  }
}
