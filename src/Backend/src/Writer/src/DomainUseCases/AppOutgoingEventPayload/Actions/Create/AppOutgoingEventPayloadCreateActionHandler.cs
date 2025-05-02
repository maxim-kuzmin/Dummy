namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEventPayload.Actions.Create;

/// <summary>
/// Обработчик действия по созданию полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class AppOutgoingEventPayloadCreateActionHandler(
  IAppDbSQLExecutionContext _appDbExecutionContext,
  IAppOutgoingEventPayloadFactory _factory,
  IAppOutgoingEventPayloadEntityRepository _repository) :
  ICommandHandler<AppOutgoingEventPayloadCreateActionCommand, Result<AppOutgoingEventPayloadSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppOutgoingEventPayloadSingleDTO>> Handle(
    AppOutgoingEventPayloadCreateActionCommand request,
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
    }

    await _appDbExecutionContext.Execute(FuncToExecute, cancellationToken).ConfigureAwait(false);

    var dto = entity.ToAppOutgoingEventPayloadSingleDTO();

    return Result.Success(dto);
  }

  private AggregateResult<AppOutgoingEventPayloadEntity> GetAggregateResult(
    AppOutgoingEventPayloadCreateActionCommand command)
  {
    var aggregate = _factory.CreateAggregate();

    var payload = command.Payload;

    aggregate.UpdateAppOutgoingEventId(command.AppOutgoingEventId);
    aggregate.UpdateData(payload.Data);
    aggregate.UpdateEntityConcurrencyTokenToDelete(payload.EntityConcurrencyTokenToDelete);
    aggregate.UpdateEntityConcurrencyTokenToInsert(payload.EntityConcurrencyTokenToInsert);
    aggregate.UpdateEntityId(payload.EntityId);
    aggregate.UpdateEntityName(payload.EntityName.ToString());
    aggregate.UpdatePosition(payload.Position);

    return aggregate.GetResultToCreate();
  }
}
