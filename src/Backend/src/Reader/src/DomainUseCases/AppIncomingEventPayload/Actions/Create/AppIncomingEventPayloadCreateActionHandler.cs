namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEventPayload.Actions.Create;

/// <summary>
/// Обработчик действия по созданию полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class AppIncomingEventPayloadCreateActionHandler(
  IAppDbNoSQLExecutionContext _appDbExecutionContext,
  IAppIncomingEventPayloadFactory _factory,
  IAppIncomingEventPayloadEntityRepository _repository) :
  ICommandHandler<AppIncomingEventPayloadCreateActionCommand, Result<AppIncomingEventPayloadSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppIncomingEventPayloadSingleDTO>> Handle(
    AppIncomingEventPayloadCreateActionCommand request,
    CancellationToken cancellationToken)
  {
    var aggregate = _factory.CreateAggregate();

    var payload = request.Payload;

    aggregate.UpdateAppIncomingEventId(request.AppIncomingEventId);
    aggregate.UpdateData(payload.Data);
    aggregate.UpdateEntityConcurrencyTokenToDelete(payload.EntityConcurrencyTokenToDelete);
    aggregate.UpdateEntityConcurrencyTokenToInsert(payload.EntityConcurrencyTokenToInsert);
    aggregate.UpdateEntityId(payload.EntityId);
    aggregate.UpdateEntityName(payload.EntityName.ToString());
    aggregate.UpdatePosition(payload.Position);

    var aggregateResult = aggregate.GetResultToCreate();

    if (aggregateResult.Data == null)
    {
      return Result.Invalid();
    }

    var validationErrors = aggregateResult.ToValidationErrors();

    if (validationErrors.Count > 0)
    {
      return Result.Invalid(validationErrors);
    }

    var entity = aggregateResult.Data.Inserted;

    if (entity == null)
    {
      return Result.Forbidden();
    }

    async Task FuncToExecute(CancellationToken cancellationToken)
    {
      entity = await _repository.AddAsync(entity, cancellationToken).ConfigureAwait(false);
    }

    await _appDbExecutionContext.Execute(FuncToExecute, cancellationToken).ConfigureAwait(false);

    var dto = entity.ToAppIncomingEventPayloadSingleDTO();

    return Result.Success(dto);
  }
}
