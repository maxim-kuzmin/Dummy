namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEventPayload.Actions.Update;

/// <summary>
/// Обработчик действия по обновлению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class AppOutgoingEventPayloadUpdateActionHandler(
  IAppDbSQLExecutionContext _appDbExecutionContext,
  IAppOutgoingEventPayloadFactory _factory,
  IAppOutgoingEventPayloadEntityRepository _repository) :
  ICommandHandler<AppOutgoingEventPayloadUpdateActionCommand, Result<AppOutgoingEventPayloadSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppOutgoingEventPayloadSingleDTO>> Handle(
    AppOutgoingEventPayloadUpdateActionCommand request,
    CancellationToken cancellationToken)
  {
    var entity = await _repository.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

    if (entity == null)
    {
      return Result.NotFound();
    }

    var aggregate = _factory.CreateAggregate(entity);

    var payload = request.Payload;

    aggregate.UpdateAppOutgoingEventId(request.AppOutgoingEventId);
    aggregate.UpdateData(payload.Data);
    aggregate.UpdateEntityConcurrencyTokenToDelete(payload.EntityConcurrencyTokenToDelete);
    aggregate.UpdateEntityConcurrencyTokenToInsert(payload.EntityConcurrencyTokenToInsert);
    aggregate.UpdateEntityId(payload.EntityId);
    aggregate.UpdateEntityName(payload.EntityName.ToString());
    aggregate.UpdatePosition(payload.Position);

    var aggregateResult = aggregate.GetResultToUpdate();

    if (aggregateResult.Data == null)
    {
      return Result.Invalid();
    }

    var validationErrors = aggregateResult.ToValidationErrors();

    if (validationErrors.Count > 0)
    {
      return Result.Invalid(validationErrors);
    }

    entity = aggregateResult.Data.Inserted;

    if (entity == null)
    {
      return Result.Forbidden();
    }

    async Task FuncToExecute(CancellationToken cancellationToken)
    {
      await _repository.UpdateAsync(entity, cancellationToken).ConfigureAwait(false);
    }

    await _appDbExecutionContext.Execute(FuncToExecute, cancellationToken).ConfigureAwait(false);

    var dto = entity.ToAppOutgoingEventPayloadSingleDTO();

    return Result.Success(dto);
  }
}
