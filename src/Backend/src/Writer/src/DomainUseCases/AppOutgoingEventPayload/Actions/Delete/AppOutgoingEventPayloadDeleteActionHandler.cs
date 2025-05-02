namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEventPayload.Actions.Delete;

/// <summary>
/// Обработчик действия по удалению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class AppOutgoingEventPayloadDeleteActionHandler(
  IAppDbSQLExecutionContext _appDbExecutionContext,
  IAppOutgoingEventPayloadFactory _factory,
  IAppOutgoingEventPayloadEntityRepository _repository) :
  ICommandHandler<AppOutgoingEventPayloadDeleteActionCommand, Result>
{
  /// <inheritdoc/>
  public async Task<Result> Handle(
    AppOutgoingEventPayloadDeleteActionCommand request,
    CancellationToken cancellationToken)
  {
    var entity = await _repository.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

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
    }

    await _appDbExecutionContext.Execute(FuncToExecute, cancellationToken).ConfigureAwait(false);

    return Result.Success();
  }

  private AggregateResult<AppOutgoingEventPayloadEntity> GetAggregateResult(AppOutgoingEventPayloadEntity entity)
  {
    var aggregate = _factory.CreateAggregate(entity);

    return aggregate.GetResultToDelete();
  }
}
