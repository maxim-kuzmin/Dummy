namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.Actions.Update;

/// <summary>
/// Обработчик действия по обновлению исходящего события приложения.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class AppOutgoingEventUpdateActionHandler(
  IAppDbSQLExecutionContext _appDbExecutionContext,
  IAppOutgoingEventFactory _factory,
  IAppOutgoingEventEntityRepository _repository) :
  ICommandHandler<AppOutgoingEventUpdateActionCommand, Result<AppOutgoingEventSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppOutgoingEventSingleDTO>> Handle(
    AppOutgoingEventUpdateActionCommand request,
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
    }

    await _appDbExecutionContext.Execute(FuncToExecute, cancellationToken).ConfigureAwait(false);

    var dto = entity.ToAppOutgoingEventSingleDTO();

    return Result.Success(dto);
  }

  private AggregateResult<AppOutgoingEventEntity> GetAggregateResult(
    AppOutgoingEventEntity entity,
    AppOutgoingEventUpdateActionCommand command)
  {
    var aggregate = _factory.CreateAggregate(entity);

    aggregate.UpdateName(command.Name);
    aggregate.UpdatePublishedAt(command.PublishedAt);

    return aggregate.GetResultToUpdate();
  }
}
