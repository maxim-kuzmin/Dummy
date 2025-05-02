namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEvent.Actions.Create;

/// <summary>
/// Обработчик действия по созданию входящего события приложения.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class AppIncomingEventCreateActionHandler(
  IAppDbNoSQLExecutionContext _appDbExecutionContext,
  IAppIncomingEventFactory _factory,
  IAppIncomingEventEntityRepository _repository) :
  ICommandHandler<AppIncomingEventCreateActionCommand, Result<AppIncomingEventSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppIncomingEventSingleDTO>> Handle(
    AppIncomingEventCreateActionCommand request,
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

    var dto = entity.ToAppIncomingEventSingleDTO();

    return Result.Success(dto);
  }

  private AggregateResult<AppIncomingEventEntity> GetAggregateResult(
    AppIncomingEventCreateActionCommand command)
  {
    var aggregate = _factory.CreateAggregate();

    aggregate.UpdateLoadedAt(command.LoadedAt);
    aggregate.UpdateEventName(command.Name);
    aggregate.UpdateProcessedAt(command.ProcessedAt);

    return aggregate.GetResultToCreate();
  }
}
