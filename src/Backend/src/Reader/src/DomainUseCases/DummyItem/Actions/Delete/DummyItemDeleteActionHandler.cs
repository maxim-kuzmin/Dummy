namespace Makc.Dummy.Reader.DomainUseCases.DummyItem.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению фиктивного предмета.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
/// <param name="_service">Сервис.</param>
public class DummyItemDeleteActionHandler(
  IAppDbNoSQLExecutionContext _appDbExecutionContext,
  IDummyItemFactory _factory,
  IDummyItemEntityRepository _repository,
  IDummyItemCommandService _service) : ICommandHandler<DummyItemDeleteActionCommand, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(DummyItemDeleteActionCommand request, CancellationToken cancellationToken)
  {
    var entity = await _repository.GetByObjectIdAsync(request.ObjectId, cancellationToken).ConfigureAwait(false);

    if (entity == null)
    {
      return Result.NotFound();
    }

    var aggregateResult = GetAggregateResult(entity);

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
      await _repository.DeleteAsync(entity, cancellationToken).ConfigureAwait(false);      

      await _service.OnEntityChanged(payload, cancellationToken).ConfigureAwait(false);
    }

    await _appDbExecutionContext.ExecuteInTransaction(FuncToExecute, cancellationToken).ConfigureAwait(false);

    return Result.Success();
  }

  private AggregateResult<DummyItemEntity> GetAggregateResult(DummyItemEntity entity)
  {
    var aggregate = _factory.CreateAggregate(entity);

    return aggregate.GetResultToDelete();
  }
}
