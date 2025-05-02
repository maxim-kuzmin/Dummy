namespace Makc.Dummy.Writer.DomainUseCases.DummyItem.Actions.Create;

/// <summary>
/// Обработчик действия по созданию фиктивного предмета.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
/// <param name="_service">Сервис.</param>
public class DummyItemCreateActionHandler(
  IAppDbSQLExecutionContext _appDbExecutionContext,
  IDummyItemFactory _factory,
  IDummyItemEntityRepository _repository,
  IDummyItemCommandService _service) :
  ICommandHandler<DummyItemCreateActionCommand, Result<DummyItemSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<DummyItemSingleDTO>> Handle(
    DummyItemCreateActionCommand request,
    CancellationToken cancellationToken)
  {
    var aggregateResult = GetAggregateResult(request);

    var entity = aggregateResult.Entity;

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
      entity = await _repository.AddAsync(entity, cancellationToken).ConfigureAwait(false);

      payload.EntityId = entity.GetPrimaryKeyAsString();

      await _service.OnEntityChanged(payload, cancellationToken).ConfigureAwait(false);
    }

    await _appDbExecutionContext.ExecuteInTransaction(FuncToExecute, cancellationToken).ConfigureAwait(false);

    var dto = entity.ToDummyItemSingleDTO();

    return Result.Success(dto);
  }

  private AggregateResult<DummyItemEntity> GetAggregateResult(DummyItemCreateActionCommand command)
  {
    var aggregate = _factory.CreateAggregate();

    aggregate.UpdateName(command.Name);

    return aggregate.GetResultToCreate();
  }
}
