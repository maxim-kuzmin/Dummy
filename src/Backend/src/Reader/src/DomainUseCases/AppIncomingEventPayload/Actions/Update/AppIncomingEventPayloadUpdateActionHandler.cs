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
    var entity = await _repository.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

    if (entity == null)
    {
      return Result.NotFound();
    }

    var aggregate = _factory.CreateAggregate(entity);

    var payload = request.Payload;

    aggregate.UpdateAppIncomingEventId(request.AppIncomingEventId);
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

    var dto = entity.ToAppIncomingEventPayloadSingleDTO();

    return Result.Success(dto);
  }
}
