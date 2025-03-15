namespace Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.Create;

/// <summary>
/// Обработчик действия по созданию события приложения.
/// </summary>
/// <param name="_appDbExecutionContext">Контекст выполнения базы данных приложения.</param>
/// <param name="_factory">Фабрика.</param>
/// <param name="_repository">Репозиторий.</param>
public class AppEventCreateActionHandler(
  IAppDbExecutionContext _appDbExecutionContext,
  IAppEventFactory _factory,
  IAppEventEntityRepository _repository) :
  ICommandHandler<AppEventCreateActionCommand, Result<AppEventSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppEventSingleDTO>> Handle(
    AppEventCreateActionCommand request,
    CancellationToken cancellationToken)
  {
    var aggregate = _factory.CreateAggregate();

    aggregate.UpdateIsPublished(request.IsPublished);
    aggregate.UpdateName(request.Name);

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

    var dto = entity.ToAppEventSingleDTO();

    return Result.Success(dto);
  }
}
