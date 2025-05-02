namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEventPayload.Actions.Update;

/// <summary>
/// Обработчик действия по обновлению полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class AppIncomingEventPayloadUpdateActionHandler(
  IAppDbNoSQLExecutionContext _appDbExecutionContext,
  IAppIncomingEventPayloadFactory _factory,
  IAppIncomingEventPayloadEntityRepository _repository) :
  ICommandHandler<AppIncomingEventPayloadUpdateActionCommand, Result<AppIncomingEventPayloadSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppIncomingEventPayloadSingleDTO>> Handle(
    AppIncomingEventPayloadUpdateActionCommand request,
    CancellationToken cancellationToken)
  {
    var entity = await _repository.GetByIdAsync(request.ObjectId, cancellationToken).ConfigureAwait(false);

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

    var dto = entity.ToAppIncomingEventPayloadSingleDTO();

    return Result.Success(dto);
  }

  private AggregateResult<AppIncomingEventPayloadEntity> GetAggregateResult(
    AppIncomingEventPayloadEntity entity,
    AppIncomingEventPayloadUpdateActionCommand command)
  {
    var aggregate = _factory.CreateAggregate(entity);

    var payload = command.Payload;

    aggregate.UpdateAppIncomingEventId(command.AppIncomingEventId);
    aggregate.UpdateData(payload.Data);
    aggregate.UpdateEntityConcurrencyTokenToDelete(payload.EntityConcurrencyTokenToDelete);
    aggregate.UpdateEntityConcurrencyTokenToInsert(payload.EntityConcurrencyTokenToInsert);
    aggregate.UpdateEntityId(payload.EntityId);
    aggregate.UpdateEntityName(payload.EntityName.ToString());
    aggregate.UpdatePosition(payload.Position);

    return aggregate.GetResultToUpdate();
  }
}
