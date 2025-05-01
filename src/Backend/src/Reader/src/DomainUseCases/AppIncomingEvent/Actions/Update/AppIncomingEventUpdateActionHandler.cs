namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEvent.Actions.Update;

/// <summary>
/// Обработчик действия по обновлению входящего события приложения.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class AppIncomingEventUpdateActionHandler(
  IAppDbNoSQLExecutionContext _appDbExecutionContext,
  IAppIncomingEventFactory _factory,
  IAppIncomingEventEntityRepository _repository) :
  ICommandHandler<AppIncomingEventUpdateActionCommand, Result<AppIncomingEventSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppIncomingEventSingleDTO>> Handle(
    AppIncomingEventUpdateActionCommand request,
    CancellationToken cancellationToken)
  {
    var entity = await _repository.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

    if (entity == null)
    {
      return Result.NotFound();
    }

    var aggregate = _factory.CreateAggregate(entity);

    aggregate.UpdateLoadedAt(request.LoadedAt);
    aggregate.UpdateEventName(request.Name);
    aggregate.UpdateProcessedAt(request.ProcessedAt);

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

    var dto = entity.ToAppIncomingEventSingleDTO();

    return Result.Success(dto);
  }
}
