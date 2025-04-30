namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.Actions.Create;

/// <summary>
/// Обработчик действия по созданию исходящего события приложения.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class AppOutgoingEventCreateActionHandler(
  IAppDbSQLExecutionContext _appDbExecutionContext,
  IAppOutgoingEventFactory _factory,
  IAppOutgoingEventEntityRepository _repository) :
  ICommandHandler<AppOutgoingEventCreateActionCommand, Result<AppOutgoingEventSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppOutgoingEventSingleDTO>> Handle(
    AppOutgoingEventCreateActionCommand request,
    CancellationToken cancellationToken)
  {
    var aggregate = _factory.CreateAggregate();
    
    aggregate.UpdateName(request.Name);
    aggregate.UpdatePublishedAt(request.PublishedAt);

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

    var dto = entity.ToAppOutgoingEventSingleDTO();

    return Result.Success(dto);
  }
}
